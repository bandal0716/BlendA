using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoveNpc : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject target;
    public GameObject out_target;
    public Animator animator;
    public TextMeshProUGUI npc_ui;
    public bool IsSit = false;
    string[] QueryList = new string[] { "��...�����Ѱ� ���ھ��!", "�ε巴�� �������� ���� ���ְ� ���ڳ׿�!","�ε巯�� ���ֿ� �����Ѱ��� �����ּ���!",
        "�����ε�... �ֽ� ���� �����!","�������� �ö󰬰� �ε巯�� ���ֿ� �ֽ����� �����Ű��ƿ�!","�ε巯�� ���ֿ� �����Ѱ��� ���� ������ �÷��ּ���!",
    "�������ֽ��� ������ �÷��ּ���!","���� ������ �԰�;��!","�������� �ö� ���� �� ���� �԰�;��!",
    "���� ���� ������ ���� ���� �����ؿ�!","���޴����� ���ϰ� �ε巯�� ���ָ� �����ؾƿ�","�� ����...���� �Ÿ��� ���ϰ� �ε巯�� ���ָ��� �����!",
    "���� ���� �������ϰ� ���޴����� ���ϰ� �ֽ��� ���ƿ�","�� ���� ���� ������ ����ؼ� �����󱸿�!!","�Ƹ�... ü���� �ִ� �ε巯�� �����ϰſ���!",
    };
    
    string[] CorrectList = new string[] { "OrangeJuice", "Jack","JackJuice"
    ,"JackJuice","OrangeJackJuice","LimeJackJuice",
    "LimeJuice","JackVodka","OrangeJackVodka",
    "Vodka","CherryJack","LimeJack",
    "CherryJuice","Vodka","CherryJack",};

    int QueryIndex = -1;
    public string collect = "";
    public GameObject glass;
    public bool Go_Out = true;
    public bool isCheck = true;

    void Start()
    {
        
        glass.GetComponent<DrinkProcess>().DrinkType = "None"; 
        npc_ui.text = "��ٸ�����..";
        out_target.SetActive(false);
    }

    void Update()
    {
        if (IsSit==false && Go_Out)
        {
            MoveToTarget();
        }
        else if (IsSit == true && Go_Out)
        {
            Invoke("MoveToOut", 3f);
        }

        if (IsSit && (QueryIndex==-1))
        {
            
            QueryIndex = ((int)Random.Range(0f, 12f));
            npc_ui.text = QueryList[QueryIndex];
            collect = CorrectList[QueryIndex];
            Debug.Log(collect);
        }

        if(glass.GetComponent<DrinkProcess>().DrinkType != "None" && isCheck==false)
        {
            string submit = glass.GetComponent<DrinkProcess>().DrinkType;
            Debug.Log(submit);
            if (submit == collect)
            {
                Debug.Log("��������");
                npc_ui.text = "�����Դϴ�!";
                //glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
                isCheck = true;
            }
            else
            {
                npc_ui.text = "����...";
                //glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
                isCheck = true;
            }
        }
    }

    void MoveToTarget()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 6f * Time.deltaTime); // ����ġ, ������, �ӵ�
        }
    }
    void MoveToOut()
    {
        glass.GetComponent<DrinkProcess>().DrinkType = "None";
        for (int i = 0; i < 4; i++)
        {
            glass.GetComponent<DrinkProcess>().Element[i] = null;
        }
        animator.SetBool("sitting", false);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (out_target.transform.position != Vector3.MoveTowards(transform.position, out_target.transform.position, 1f))
        {
            //Debug.Log("������.");
            transform.position = Vector3.MoveTowards(transform.position, out_target.transform.position, 6f * Time.deltaTime); // ����ġ, ������, �ӵ�
        }
        npc_ui.text = "��������...";
    }
    void setChair()
    {
        target.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chair"))
        {
            Go_Out = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("sitting", true);
            target.SetActive(false);
            IsSit = true;
            out_target.SetActive(true);
            isCheck = false;
        }
        else if (other.gameObject.CompareTag("OutPos"))
        {
            IsSit = false;
            Invoke("setChair", 0.5f);
            QueryIndex = -1;
            out_target.SetActive(false);
            GameManager.GetComponent<GameManager>().IsMan = !(GameManager.GetComponent<GameManager>().IsMan);
            isCheck = false;
        }
    }
}
    
