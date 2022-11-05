using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoveNpc : MonoBehaviour
{

    public GameObject target;
    public GameObject out_target;
    public Animator animator;
    public TextMeshProUGUI npc_ui;
    public bool IsSit = false;
    string[] QueryList = new string[] { "������ �� �ּ���!", "�������� ���� ���� �ּ���!"};
    string[] CorrectList = new string[] { "������ �ֽ�", "��ٴϿ�" };
    int QueryIndex = -1;
    public string collect = "";
    public GameObject glass;
    public bool Go_Out = true;

    void Start()
    {
        //gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        glass.GetComponent<DrinkProcess>().DrinkType = "None"; 
        npc_ui.text = "��ٸ�����..";
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
            QueryIndex = ((int)Random.Range(0f, 2f));
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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.06f); // ����ġ, ������, �ӵ�
        }
    }
    void MoveToOut()
    {
        animator.SetBool("sitting", false);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (out_target.transform.position != Vector3.MoveTowards(transform.position, out_target.transform.position, 1f))
        {
            Debug.Log("������.");
            transform.position = Vector3.MoveTowards(transform.position, out_target.transform.position, 0.06f); // ����ġ, ������, �ӵ�
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
        }
        else if (other.gameObject.CompareTag("OutPos"))
        {
            IsSit = false;
            Invoke("setChair", 0.5f);
            QueryIndex = -1;
        }
    }
}
    
