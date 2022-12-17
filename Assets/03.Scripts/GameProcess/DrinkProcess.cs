using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class DrinkProcess : MonoBehaviour
{
    // ���̴� ���� ����
    float a;
    public GameObject glass;
    //Renderer glassR = glass.GetComponent<Renderer>();
    //Renderer glassTR = glass.transform.GetComponent<Renderer>();

    public GameObject[] FruitList = new GameObject[3];
    //public GameObject[] AlcoholList = new GameObject[2];
    //public GameObject[] NonAlcoholList = new GameObject[2];

    public GameObject FruitPoint;
    public string DrinkType = "None";

    //���� UI ����
    public int Score = 0;
    public TextMeshProUGUI ScoreBoard;

    //public string DrinkType = "None";
    
    //���� ���� ���빰 �̰� ������ if������ �Ǵ�.
    //0:�� 1:�ֽ� 2:���� 4:�߰� ��
    public GameObject[] Element = new GameObject[4];

    public GameObject[] OrangeJuice = new GameObject[4];
    public GameObject[] Jack = new GameObject[4];
    public GameObject[] Vodka = new GameObject[4];
    public GameObject[] JackJuice = new GameObject[4];
    public GameObject[] JackVodka = new GameObject[4];
    public GameObject[] OrangeJackJuice = new GameObject[4];
    public GameObject[] OrangeJackVodka = new GameObject[4];
    public GameObject[] LimeJack = new GameObject[4];
    public GameObject[] LimeJackJuice = new GameObject[4];
    public GameObject[] LimeJuice = new GameObject[4];
    public GameObject[] CherryJack = new GameObject[4];
    public GameObject[] CherryJuice = new GameObject[4];

    public Vector3 nowPosition;

    


    // Start is called before the first frame update
    private void Awake()
    {
        nowPosition = this.transform.position;
    }
    void Start()
    {
        for(int i=0; i<4; i++)
        {
            Element[i] = null;
        }

        //���̴� ����
        Renderer glassR = glass.GetComponent<Renderer>();
        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        glassR.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        a = glassTR.material.GetFloat("_FillAmount");
        //���� UI
        ScoreBoard.text = Score.ToString() + " ��";
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

        //Debug.Log("Z����");
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
            Debug.Log("���ø�Ʈ");
            /*
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
            */
            /*
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
            */
            if (Element.SequenceEqual(OrangeJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "OrangeJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                /*
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }*/
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f,123f,0f));
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }           
            else if (Element.SequenceEqual(Jack) == true)
            {
                Debug.Log("����");
                DrinkType = "Jack";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                /*
                for (int i = 0; i < 4; i++)
                {
                    Element[i] = null;
                }*/
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 161f, 91f));
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";

            }
            else if (Element.SequenceEqual(Vodka) == true)
            {
                Debug.Log("����");
                DrinkType = "Vodka";
                Debug.Log(DrinkType);
                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 255f, 255f));
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(JackJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "JackJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 132f, 40f));
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(JackVodka) == true)
            {
                Debug.Log("����");
                DrinkType = "JackVodka";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 182f, 126f));
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }

            else if (Element.SequenceEqual(OrangeJackJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "OrangeJackJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 132f, 40f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";

            }
            else if (Element.SequenceEqual(OrangeJackVodka) == true)
            {
                Debug.Log("����");
                DrinkType = "OrangeJackVodka";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 182f, 126f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(LimeJack) == true)
            {
                Debug.Log("����");
                DrinkType = "LimeJack";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 161f, 91f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(LimeJackJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "LimeJackJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 132f, 40f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(LimeJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "LimeJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 123f, 0f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(CherryJack) == true)
            {
                Debug.Log("����");
                DrinkType = "CherryJack";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 161f, 91f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else if (Element.SequenceEqual(CherryJuice) == true)
            {
                Debug.Log("����");
                DrinkType = "CherryJuice";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                //Element = new GameObject[3];
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(255f, 123f, 0f));
                DeleteChilds();
                Score = Score + 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }
            else
            {
                Debug.Log("����");
                DrinkType = "Fail";
                Debug.Log(DrinkType);

                this.transform.position = nowPosition;
                Renderer glassTR = glass.transform.GetComponent<Renderer>();
                glassTR.material.SetFloat("_FillAmount", 1);
                glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(0f, 0f, 0f));
                DeleteChilds();
                Score = Score - 500;
                ScoreBoard.text = Score.ToString() + " ��";
            }

            

        }

        if (other.gameObject.CompareTag("Reset"))
        {
            //Debug.Log("����");
            DrinkType = "None";
            Debug.Log(DrinkType);
            Renderer glassTR = glass.transform.GetComponent<Renderer>();
            glassTR.material.SetFloat("_FillAmount", 1);
            glass.GetComponent<Renderer>().material.SetColor("_Colour", new Color(0f, 0f, 0f));
            DeleteChilds();
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
        //���� �߰��� ���
        //else if (other.gameObject.CompareTag("Lemon"))
        //{
        //    Debug.Log("�����浹");
        //    if (Element[2] == null)
        //    {
        //        Element[2] = FruitList[3];
        //        GameObject temp = Instantiate(Element[2], FruitPoint.transform.position, cur);
        //        temp.transform.SetParent(FruitPoint.transform);
        //    }
        //}

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

    public void DeleteChilds()
    {       
        for (int i = 0; i < FruitPoint.transform.childCount; i++)
        {
            Destroy(FruitPoint.transform.GetChild(i).gameObject);
        }
    }


}
