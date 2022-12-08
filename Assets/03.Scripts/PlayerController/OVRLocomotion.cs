using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRLocomotion : MonoBehaviour
{
    // PlayerTurn�� ����Ұ���, PlayerRotate�� ����Ұ��� ���ϴ� ����
    public bool turnRotate = false;

    public Transform player;

    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float rotateAngle = 25f;     // ������ ȸ�� ������ �����ϴ� ����

    private Vector3 movePosition = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;

    private Vector2 moveValue = Vector2.zero;       // ���� ��Ʈ�ѷ��� Thumbstick Value
    private Vector2 rotateValue = Vector2.zero;     // ������ ��Ʈ�ѷ��� Thubmstick Value

    void Update()
    {
        //PlayerMove();

        if (!turnRotate)
        {
            //PlayerRotate();
        }
        else
        {
            //PlayerTurn();
        }
    }

    // ���� ��Ʈ�ѷ��� LThumbstick�� ���� ���� �̵��ϴ� ���
    private void PlayerMove()
    {
        moveValue = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        movePosition.Set(moveValue.x, 0, moveValue.y);

        player.Translate(movePosition * moveSpeed * Time.deltaTime);
    }

    // ������ ��Ʈ�ѷ��� RThumbstick�� ���� ���� ȸ��(�ε巯�� ȸ��)�ϴ� ���
    private void PlayerRotate()
    {
        rotateValue = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        player.Rotate(Vector3.up * rotateValue.x * rotateSpeed * Time.deltaTime);
    }

    private void PlayerTurn()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            OVRFade.Instance.AutoFade();
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y + rotateAngle, 0);
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            OVRFade.Instance.AutoFade();
            player.rotation = Quaternion.Euler(0, player.rotation.eulerAngles.y - rotateAngle, 0);
        }
    }
}
