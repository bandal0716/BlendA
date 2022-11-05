using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RayFluid : MonoBehaviour
{
    float a;
    private RaycastHit hit; // �浹�� ��ü
    public float raycastDistance = 10f;
    public GameObject glass;
    public GameObject bottle;
    Vector3 dir = new Vector3(0, 1, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer glassR = glass.GetComponent<Renderer>();
        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        glassR.material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        a = glassTR.material.GetFloat("_FillAmount");
        glassTR.material.SetFloat("_FillAmount", 1.0f);
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = new Vector3(transform.rotation.eulerAngles.x, 1, transform.rotation.eulerAngles.z);
        //Vector3 f = gameObject.transform.position;
        //dir = new Vector3(-f.x, -dir.y, -f.z);
        //dir = dir.normalized;
        /*
        if (transform.rotation.eulerAngles.x == 0 && transform.rotation.eulerAngles.z==0)
        {
            dir = new Vector3(0, 1, 0);
        }
        else
        {
            dir += new Vector3(bottle.transform.rotation.eulerAngles.x, bottle.transform.rotation.eulerAngles.y, bottle.transform.rotation.eulerAngles.z);
        }
        */
        //dir = dir.normalized;
        //dir = new Vector3(dir.x%360, dir.y % 360, dir.z % 360);
        #region ���� ������
        //Vector3 look = transform.TransformDirection(dir);

        //Debug.DrawRay(transform.position, look * raycastDistance, Color.green, 0.5f);

        //if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        //{
        //    if (hit.collider.gameObject.CompareTag("glass"))
        //    {
        //        Debug.Log("ä����");
        //        if (a > 0)
        //        {
        //            a -= 0.01f;
        //            Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //            glassTR.material.SetFloat("_FillAmount", a);

        //        }
        //        else
        //        {
        //            a = 0;
        //            Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //            glassTR.material.SetFloat("_FillAmount", a);
        //        }
        //    }
        //}
        //else
        //{
        //    /*
        //    if (a < 1)
        //    {
        //        a += 0.1f;
        //        Renderer glassTR = glass.transform.GetComponent<Renderer>();
        //        glassTR.material.SetFloat("_FillAmount", a);
        //    }
        //    */
        //}
        #endregion

        InvokeRepeating("RayFunction", 1.0f, 3.0f);
        
    }

    void RayFunction()
    {
        Vector3 look = transform.TransformDirection(dir);

        Debug.DrawRay(transform.position, look * raycastDistance, Color.green, 0.5f);

        //if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        //if(Physics.BoxCast(transform.position, transform.localScale, look, out hit, transform.parent.rotation, raycastDistance))
        if (Physics.Raycast(transform.position, look, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.CompareTag("glass"))
            {
                Debug.Log("ä����");
                if (this.gameObject.layer == LayerMask.NameToLayer("Alcohol"))
                {
                    //�ڱ� �ڽ��� �±׳� ���̾ �������� ��������� üũ.
                    if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] == null)
                    {
                        GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] = transform.parent.gameObject;
                        //���� �� ������Ʈ�� �±� üũ
                    }
                }

                if (this.gameObject.layer == LayerMask.NameToLayer("NonAlcohol"))
                {
                    //�ڱ� �ڽ��� �±׳� ���̾ �������� ��������� üũ.
                    if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[1] == null)
                    {
                        GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[1] = transform.parent.gameObject;
                        //���� �� ������Ʈ�� �±� üũ
                    }
                }

                ////�ڱ� �ڽ��� �±׳� ���̾ �������� ��������� üũ.
                //if (GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] == null)
                //{
                //    GameObject.Find("Glass").GetComponent<DrinkProcess>().Element[0] = transform.parent.gameObject;
                //    //���� �� ������Ʈ�� �±� üũ
                //}
                
                if (a > 0)
                {
                    a -= 0.002f;
                    Renderer glassTR = glass.transform.GetComponent<Renderer>();
                    glassTR.material.SetFloat("_FillAmount", a);

                }
                else
                {
                    a = 0;
                    Renderer glassTR = glass.transform.GetComponent<Renderer>();
                    glassTR.material.SetFloat("_FillAmount", a);
                }
            }
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Vector3 look = transform.TransformDirection(dir);
        Gizmos.color = Color.green;
        // Physics.BoxCast (�������� �߻��� ��ġ, �簢���� �� ��ǥ�� ���� ũ��, �߻� ����, �浹 ���, ȸ�� ����, �ִ� �Ÿ�)
        //���� ����Ʈ�� ��������ǥ,
        if (Physics.BoxCast(transform.position, transform.localScale, look, out hit, transform.parent.rotation, raycastDistance))
        {
            Gizmos.DrawRay(transform.position, look);
            Gizmos.DrawWireCube(transform.position + look * hit.distance, transform.localScale);
            if (hit.collider.gameObject.CompareTag("glass"))
            {
                Gizmos.DrawRay(transform.position, look);
                Gizmos.DrawWireCube(transform.position + look * hit.distance, transform.localScale);
            }   
        }
    }
    */
}