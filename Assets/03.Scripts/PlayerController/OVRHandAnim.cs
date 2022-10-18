using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRHandAnim : MonoBehaviour
{
    // OVR ��Ʈ�ѷ� ��ġ�� Ȯ���ϱ� ���� ����
    public OVRInput.Controller controller;

    // Hand ���� �ִϸ����� ������Ʈ ���� ����
    [SerializeField]
    private Animator handAnim = null;

    // Trigger Button�� ������ ���� ���� ���ϴ� ��

    private float triggerValue = 0;

    // Grip Button�� ������ ���� ���� ���ϴ� ��
    private float gripValue = 0;


    void Start()
    {
        
    }


    void Update()
    {
        ControllerInputState();

        //Hand �ִϸ����� ������Ʈ�� �Ķ����(Triggerm Grip)���� �����ϴ� ���
        handAnim.SetFloat("Trigger", triggerValue);
        handAnim.SetFloat("Grip", gripValue);
    }

    private void ControllerInputState()
    {
        //�Է��� ��Ʈ�ѷ� ��ġ�� ���� �ش� ��Ʈ�ѷ� ��ư�� Trigger, Grip Value�� �����ϴ� ���
        triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

    }

}
