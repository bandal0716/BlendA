using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkProcess : MonoBehaviour
{
    public GameObject[] FruitList = new GameObject[3];
    //public GameObject[] AlcoholList = new GameObject[2];
    //public GameObject[] NonAlcoholList = new GameObject[2];

    public GameObject FruitPoint;
    //public string DrinkType = "None";
    //���� ���� ���빰 �̰� ������ if������ �Ǵ�.
    //0:�� 1:�ֽ� 2:����
    public GameObject[] Element = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<3; i++)
        {
            Element[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Quaternion cur = this.transform.rotation;
        float changeRot = 0;

        Debug.Log("Z����");
        if (cur.eulerAngles.z < 0)
        {
            changeRot = 100.0f;
        }
        else
        {
            changeRot = -100.0f;
        }

        Quaternion rotZ = Quaternion.Euler(new Vector3(0, 0, changeRot));
        cur *= rotZ;

        if (other.gameObject.CompareTag("Orange"))
        {
            
            Debug.Log("�������浹");
            if (Element[2] == null)
            {
                Element[2] = FruitList[0];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
        else if (other.gameObject.CompareTag("Lime"))
        {
            Debug.Log("�����浹");
            if (Element[2] == null)
            {
                Element[2] = FruitList[1];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
        else if (other.gameObject.CompareTag("Cherry"))
        {
            Debug.Log("ü���浹");
            if (Element[2] == null)
            {
                Element[2] = FruitList[2];
                GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
                temp.transform.SetParent(FruitPoint.transform);
            }
        }
    }
}
