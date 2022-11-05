using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFluid : MonoBehaviour
{
    //��ü ����
    public GameObject Obi;
    //��ü ��ȯ����
    public Transform FluidPoint;
    public bool isFluid = false;

    public bool isX=false;
    public bool isZ=false;

    // Update is called once per frame
    void Update()
    {
        isZ = ((Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) % 360) >= 60 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) % 360) <= 270);
        isX = ((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) % 360) >= 60 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) % 360) <= 270);
        //���� ������ ��������
        if (isX || isZ)
        {
            //��ü ����
            if (isFluid == false)
            {
                Debug.Log("�������");
                isFluid = true;
                GameObject temp = Instantiate(Obi, FluidPoint.position, Quaternion.Euler(0, 0, 0));
                temp.transform.SetParent(FluidPoint.transform);
            }
        }
        
        if (!(isX)&&!(isZ))
        {
            isFluid = false;
        }
    }
}
