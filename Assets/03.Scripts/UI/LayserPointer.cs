using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // ������
    private RaycastHit Collided_object; // �浹�� ��ü
    private GameObject currentObject;   // ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü

    public float raycastDistance = 300f; // ������ ������ ���� �Ÿ�
    void Start()
    {
        // ��ũ��Ʈ�� ���Ե� ��ü�� ���� ��������� ������Ʈ�� �ְ��ִ�.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // ������ �������� ���� ǥ��
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 255, 0.5f);
        layser.material = material;
        // �������� ����Q���� 2���� �ʿ� �� ���� ������ ��� ǥ�� �� �� �ִ�.
        layser.positionCount = 2;
        // ������ ���� ǥ��
        layser.startWidth = 0.01f;
        layser.endWidth = 0.01f;
    }
    
    void Update()
    {
        layser.SetPosition(0, transform.position); // ù��° ������ ��ġ
                                                   // ������Ʈ�� �־� �����ν�, �÷��̾ �̵��ϸ� �̵��� ���󰡰� �ȴ�.
                                                   // �� �����(�浹 ������ ����)
        
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        //����ĳ��Ʈ �浹
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))
        {
            layser.SetPosition(1, Collided_object.point);
            if (Collided_object.collider.gameObject.CompareTag("MainMenu"))
            {
                //layser.SetPosition(1, Collided_object.point);
            }
            //���� ��ŸƮ ��ư�̸�
            if (Collided_object.collider.gameObject.CompareTag("Start"))
            {
                //layser.SetPosition(0, Collided_object.point);
                Debug.Log("��ŸƮ ��ư�� ���� �浹!");
                //�������� 1�� �ε����� ��Ʈ�� ������Ʈ�� �ְڴٴ� ��.

                //�޼�
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
                {
                    Debug.Log("��ŸƮ �޼� Ʈ���� ����");
                    //�ε� ��
                    SceneManager.LoadScene("Main");
                }

                //������
                if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Debug.Log("��ŸƮ ������ Ʈ���� ����");
                    //�ε� ��
                    SceneManager.LoadScene("Main");
                }
            } 
            else if (Collided_object.collider.gameObject.CompareTag("Quit"))
            {
                //layser.SetPosition(1, Collided_object.point);
                Debug.Log("������ ��ư�� ���� �浹!");
                //�������� 1�� �ε����� ��Ʈ�� ������Ʈ�� �ְڴٴ� ��.

                //�޼�
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
                {
                    Debug.Log("������ �޼� Ʈ���� ����");
                    //Application.Quit();
                    EditorApplication.Exit(0);
                }

                //������
                if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Debug.Log("������ ������ Ʈ���� ����");
                    //Application.Quit();
                    EditorApplication.Exit(0);
                }
            }
        }
        else
        {
            // �������� ������ ���� ���� ������ ������ �ʱ� ���� ���̸�ŭ ��� �����.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance * 100));

            // �ֱ� ������ ������Ʈ�� Button�� ���
            // ��ư�� ���� �����ִ� �����̹Ƿ� �̰��� Ǯ���ش�.

            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }
        }

        /*void OnDrawGizmos()
        {
            float maxDistance = 300;
            RaycastHit hit;
            
            // Physics.Raycast (�������� �߻��� ��ġ, �߻� ����, �浹 ���, �ִ� �Ÿ�)
            
            Gizmos.color = Color.red;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {
                if(hit.collider.gameObject.CompareTag("Start"))
                {
                    Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
                }
            }
                
        }*/

        /*
        // �浹 ���� ��
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))
        {
            layser.SetPosition(1, Collided_object.point);

            // �浹 ��ü�� �±װ� Button�� ���
            if (Collided_object.collider.gameObject.CompareTag("Button"))
            {
                // ��ŧ���� �� �����ܿ� ū ���׶�� �κ��� ���� ���
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    // ��ư�� ��ϵ� onClick �޼ҵ带 �����Ѵ�.
                    Collided_object.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                else
                {
                    //Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    //currentObject = Collided_object.collider.gameObject;
                }
            }
        }
        else
        {
            // �������� ������ ���� ���� ������ ������ �ʱ� ���� ���̸�ŭ ��� �����.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // �ֱ� ������ ������Ʈ�� Button�� ���
            // ��ư�� ���� �����ִ� �����̹Ƿ� �̰��� Ǯ���ش�.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }

        }
        */
    }

    private void LateUpdate()
    {
        // ��ư�� ���� ���        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);
        }

        // ��ư�� �� ���          
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            layser.material.color = new Color(0, 195, 255, 0.5f);
        }
    }
}


