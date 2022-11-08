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
        "�����ε�... �ֽ� ���� �����Ű��ƿ�!","�������� �ö󰬰� �ε巯�� ���ֿ� �ֽ����� �����Ű��ƿ�!","�ε巯�� ���ֿ� �����Ѱ��� ���� ������ �÷��ּ���!",
    "�������ֽ��� ������ �÷��ּ���!","���� ������ �԰�;��!","�������� �ö� ���� �� ���� �԰�;��!",
    "���� ���� ������ ���� ���� �����ؿ�!","���޴����� ���ϰ� ���ְ� �־����� ���ƿ�","�� ����...���� �Ÿ��� ���ϰ� ������ ���ָ��� �����!",
    "���� ���� �������ϰ� ���޴����� ������ ���ƿ�","�� ���� ���� ������ �����󱸿�!!","�Ƹ�... ü���� �ִ� �ε巯�� �����ϰſ���!",
    };
    
    string[] CorrectList = new string[] { "OrangJuice", "Jack","JackJuice"
    ,"JackJuice","OrangeJackJuice","LimeJackJuice",
    "LimeJuice","JackVodka","OrangeJackVodka",
    "Vodka","CherryJack","LimeJack",
    "CherryJuice","Vodka","CherryJack",};

    int QueryIndex = -1;
    public string collect = "";
    public GameObject glass;
    public bool Go_Out = true;

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
        }

        if(glass.GetComponent<DrinkProcess>().DrinkType != "None")
        {
            string submit = glass.GetComponent<DrinkProcess>().DrinkType;
            if (submit == collect)
            {
                npc_ui.text = "�����Դϴ�!";
                glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
            }
            else
            {
                npc_ui.text = "����...";
                glass.GetComponent<DrinkProcess>().DrinkType = "None";
                Go_Out = true;
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
        }
        else if (other.gameObject.CompareTag("OutPos"))
        {
            IsSit = false;
            Invoke("setChair", 0.5f);
            QueryIndex = -1;
            out_target.SetActive(false);
            GameManager.GetComponent<GameManager>().IsMan = !(GameManager.GetComponent<GameManager>().IsMan);           
        }
    }
}
    
