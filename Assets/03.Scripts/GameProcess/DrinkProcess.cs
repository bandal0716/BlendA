using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrinkProcess : MonoBehaviour
{
    public GameObject[] FruitList = new GameObject[3];
    //public GameObject[] AlcoholList = new GameObject[2];
    //public GameObject[] NonAlcoholList = new GameObject[2];

    public GameObject FruitPoint;
    public string DrinkType = "None";

    //public string DrinkType = "None";
    
    //���� ���� ���빰 �̰� ������ if������ �Ǵ�.
    //0:�� 1:�ֽ� 2:����
    public GameObject[] Element = new GameObject[3];

    public GameObject[] HighBall = new GameObject[3];
    public GameObject[] ScrewDriver = new GameObject[3];
    public Vector3 nowPosition;


    // Start is called before the first frame update
    private void Awake()
    {
        nowPosition = this.transform.position;
    }
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

    private void OnCollisionEnter(Collision collision)
    {
        //Element ���� ���ҿ� null�� ������ ��ũ��Ʈ ��Ȱ��
        //if (collision.collider.gameObject.CompareTag("Complete"))
        //{
        //    if (Element[0] == null)
        //    {
        //        Debug.Log("0�� �����");
        //    }
        //    if (Element[1] == null)
        //    {
        //        Debug.Log("1�� �����");
        //    }
        //    if (Element[2] == null)
        //    {
        //        Debug.Log("2�� �����");
        //    }
        //    //�ϼ�ǰ ��
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (Element[i] != null)
        //        {
        //            if (Element.SequenceEqual(HighBall) == true)
        //            {
        //                Debug.Log("���̺� ����");
        //                DrinkType = "HighBall";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];


        //            }
        //            else if (Element.SequenceEqual(ScrewDriver) == true)
        //            {
        //                Debug.Log("��ũ������̹� ����");
        //                DrinkType = "ScrewDriver";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];
        //            }
        //            else
        //            {
        //                Debug.Log("����");
        //                DrinkType = "Fail";
        //            }
        //        }
        //    }

        //}
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

        //�ϼ�ǰ ��------------------------------------------------------------------------
        if (other.gameObject.CompareTag("Complete"))
        {
            if (Element[0] == null)
            {
                Debug.Log("0�� �����");
            }
            if (Element[1] == null)
            {
                Debug.Log("1�� �����");
            }
            if (Element[2] == null)
            {
                Debug.Log("3�� �����");
            }
            
            for (int i = 0; i < 3; i++)
            {
                if (Element[i] != null)
                {

                    if (Element.SequenceEqual(HighBall) == true)
                    {
                        Debug.Log("���̺� ����");
                        DrinkType = "HighBall";
                        this.transform.position = nowPosition;
                        Element = new GameObject[3];
                    }                   
                    else if (Element.SequenceEqual(ScrewDriver) == true)
                    {
                        Debug.Log("��ũ������̹� ����");
                        DrinkType = "ScrewDriver";
                        this.transform.position = nowPosition;
                        Element = new GameObject[3];
                    }
                    else
                    {
                        Debug.Log("����");
                        DrinkType = "Fail";
                    }
                }
            }

        }
        //----------------------------------------------------------------

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

        //Element ���� ���ҿ� null�� ������ ��ũ��Ʈ ��Ȱ��
        //if (other.gameObject.CompareTag("Complete"))
        //{
        //    if (Element[0] == null)
        //    {
        //        Debug.Log("0�� �����");
        //    }
        //    else if (Element[1] == null)
        //    {
        //        Debug.Log("1�� �����");
        //    }
        //    else if (Element[2] == null)
        //    {
        //        Debug.Log("3�� �����");
        //    }
        //    //�ϼ�ǰ ��
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (Element[i] != null)
        //        {
        //            if (Element.SequenceEqual(HighBall) == true)
        //            {
        //                Debug.Log("���̺� ����");
        //                DrinkType = "HighBall";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];


        //            }
        //            else if (Element.SequenceEqual(ScrewDriver) == true)
        //            {
        //                Debug.Log("��ũ������̹� ����");
        //                DrinkType = "ScrewDriver";
        //                this.transform.position = nowPosition;
        //                Element = new GameObject[3];
        //            }
        //            else
        //            {
        //                Debug.Log("����");
        //                DrinkType = "Fail";
        //            }
        //        }
        //    }

        //}

    }
    
    
}
