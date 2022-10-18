using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineInteraction : MonoBehaviour
{
    // Outline ������Ʈ ��� ����
    public bool useOutline = false;

    // ���۰� ���ÿ� Outline�� ǥ���� ������ ����
    public bool playOnAwake = false;

    // OutLine�� �÷� ���� ����
    public Color positiveColor = Color.white;

    // Quick Outline ������Ʈ�� �����ϴ� ����
    private Outline outline = null;

    void Start()
    {
        // ���ӿ�����Ʈ�� �ƿ������� ���ٸ�
        if (useOutline)
        {
            // ���ӿ�����Ʈ�� �ƿ����� ������Ʈ�� �߰��Ͽ� �Ҵ�
            if(gameObject.GetComponent<Outline>() == null)
            {
                outline = gameObject.AddComponent<Outline>();
            }
            else
            {
                // �ƿ����� ������Ʈ�� �ֵ��� �ش� ������Ʈ�� �����Ͽ� �Ҵ�
                outline = GetComponent<Outline>();
            }
        }
        // �ƿ����� ������Ʈ�� ����
        else
        {
            Destroy(GetComponent<Outline>());
        }

        //���۰� ���ÿ� �ƿ������� ǥ���� ������
        if (playOnAwake)
            ShowOutline();
        // ���� �������� ����
        else
            HideOutline();

    }

    // �ƿ������� ǥ���ϴ� ���
    public void ShowOutline()
    {
        outline.OutlineColor = positiveColor;       //�ƿ����� ���� ����
        outline.enabled = true;     //�ƿ����� Ȱ��ȭ
    }

    // �ƿ������� ����� ���
    public void HideOutline()
    {
        outline.enabled = false;        //�ƿ����� ��Ȱ��ȭ
    }

}
