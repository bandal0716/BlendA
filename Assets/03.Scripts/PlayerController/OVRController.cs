using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRController : MonoBehaviour
{
    // OVR ��Ʈ�ѷ� ��ġ�� Ȯ���ϱ� ���� ����
    public OVRInput.Controller controller;

    // OVR Player ����
    public Transform player = null;

    // ��Ʈ�ѷ��� Transform�� Rigidbody ����
    private Transform handTransform = null;     // �����ϴ� ������Ʈ�� ��ġ, ȸ��
    private Rigidbody handRigidbody = null;     // �������� ������Ʈ�� velocity ��

    // ��Ʈ�ѷ��� �浹�� ��, PickUp�� �� �ִ� ������Ʈ�� �����ϴ� ����
    private Rigidbody attachedObject;

    // ��Ʈ�ѷ��� �浹�ϴ� �ټ��� �浹ü�� �����ϱ� ���� �迭 ����
    private List<Rigidbody> contactRigidbodies = new List<Rigidbody>();

    // �����ƴ����� �����ؼ� Outline�� ǥ�����ִ� flag ����
    private bool isAttached = false;

    void Start()
    {
        handTransform = GetComponent<Transform>();
        handRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Grip ��ư�� ������ �� ObjectPickUp() �Լ� ȣ��
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            isAttached = true;

            ObjectPickUp();
        }       
        // Grip ��ư�� ���� �� ObjectDrop() �Լ� ȣ��
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            isAttached = false;

            ObjectDrop();
        }

    }

    // ������Ʈ�� ��Ʈ�ѷ��� ������Ű�� ���
    private void ObjectPickUp()
    {
        // attachObject = ���� ����� �浹ü�� ����ؼ� �־��ֱ�
        attachedObject = GetNearestRigidbody();

        // attachObject�� ���� ��
        if (attachedObject == null)
            return;

        // attachObject�� rigidbody ���� ������ ����
        attachedObject.useGravity = false; // ������ ������Ʈ�� �߷� ��Ȱ��ȭ
        attachedObject.isKinematic = true; // ������ ������Ʈ�� ����ȭ ��Ȱ��ȭ

        // attachObject�� ��ġ, ȸ������ = handTransform���� ���� (���� ����, ��ġ& ȸ�� �ʱ�ȭ)
        // attachedObject.transform.position = handTransform.position;
        // attachedObject.transform.rotation = handTransform.rotation;

        // attachObject�� Transform Parentfmf handTransform���� ���� (���ϵ�ȭ, ����)
        attachedObject.transform.parent = handTransform;
    }

    // ��Ʈ�ѷ��� ������ ������Ʈ�� �����ִ� ���
    private void ObjectDrop()
    {
        // attachObject�� ���� ��
        if (attachedObject == null)
            return;

        // attachObject�� rigidbody ���� ������ ����
        attachedObject.useGravity = true; // ������ ������Ʈ�� �߷� ��Ȱ��ȭ
        attachedObject.isKinematic = false; // ������ ������Ʈ�� ������ ��Ȱ��ȭ

        // attachObject�� handTransform�� ������ �ִ� ���� Velocity���� ����
        attachedObject.velocity += player.rotation * OVRInput.GetLocalControllerVelocity(controller);
        attachedObject.angularVelocity += player.rotation * OVRInput.GetLocalControllerAngularVelocity(controller);


        // ������ ���� ������Ʈ�� ����ش�
        //attachedObject = null;

        // attachObject�� Transform Parentfmf handTransform���� ���� (���ϵ�ȭ, ����)
        attachedObject.transform.parent = null;
    }

    // ��Ʈ�ѷ��� �浹�� Rigidbody �� ���� ����� �浹ü�� �Ǻ��ϴ� ���
    private Rigidbody GetNearestRigidbody()
    {

        // Rigidbody�� �����ϴ� �ӽú���
        Rigidbody nearestRigidbody = null;

        // �񱳵� Distance ���� �����ϴ� ���� (�ּ� ��)
        float minDistance = float.MaxValue;

        // ���� Distance ���� �����ϴ� ����
        float distance = 0;

        // List�� ����� �浹ü ����Ʈ �� ����� Rigidbody�� ����ϴ� ���
        foreach (Rigidbody rigidbody in contactRigidbodies)
        {
            // ���� rigidbody�� HandTransform ������ �Ÿ��� ��
            distance = Vector3.Distance(rigidbody.transform.position, handTransform.position);

            // ���� distance�� minDistance�� ��
            if(distance < minDistance)
            {
                // �ּ� �Ÿ� ���� ����
                minDistance = distance;

                // ��ȯ�� ���� ����� Rigidbody ��ü�� ����
                nearestRigidbody = rigidbody;
            }           
        }

        // ���� Rigidbody�� ��ȯ

        return nearestRigidbody;
    }

    // ��Ʈ�ѷ��� ������Ʈ�� �����ϴ� ����
    // 1. Grip ��ư�� ������
    // 2. �浹�� �����ؾ� �Ѵ�
    // 3. �浹ü�� ���� �浹�� �Ͼ�� �Ѵ�

    // ��Ʈ�ѷ��� �浹�� ������Ʈ�� ���� ��
    private void OnTriggerEnter(Collider other)
    {
        // �±װ� "InteractionObject"�� ������Ʈ�� �����ϴ� ���
        // �ش� ���ӿ�����Ʈ�� attactedObject�� �Ҵ��ϵ�, Rigidbody�� �Ҵ�
        if (other.CompareTag ("Object"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("glass"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("Orange"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if (other.CompareTag("Cherry"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }
        else if(other.CompareTag("Lime"))
        {
            //attachedObject = other.GetComponent<Rigidbody>();

            // �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().ShowOutline();
            }
        }

    }

    // ��Ʈ�ѷ��� �浹�� ������Ʈ�� �������� ��
    private void OnTriggerExit(Collider other)
    {
        // �±װ� "InteractionObject"�� ������Ʈ�� �����ϴ� ���
        // attactedObject�� null�� ����
        if (other.CompareTag("Object"))
        {
            //attachedObject = null;

            // �迭�� �浹ü�� ����
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� ��Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if (other.CompareTag("glass"))
        {
            //attachedObject = null;

            // �迭�� �浹ü�� ����
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� ��Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Orange"))
        {
            //attachedObject = null;

            // �迭�� �浹ü�� ����
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� ��Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Cherry"))
        {
            //attachedObject = null;

            // �迭�� �浹ü�� ����
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� ��Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }
        else if(other.CompareTag("Lime"))
        {
            //attachedObject = null;

            // �迭�� �浹ü�� ����
            contactRigidbodies.Remove(other.GetComponent<Rigidbody>());

            // ���� ��Ʈ�ѷ��� �������� �ʾҴٸ�
            if (!isAttached)
            {
                // �浹�� ���� ������Ʈ�� �ƿ������� ��Ȱ��ȭ �Ѵ�.
                other.GetComponent<OutlineInteraction>().HideOutline();
            }
        }


    }
}
