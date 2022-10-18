using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{

    int ID;
    public GameObject Cylinder;
    
    void Start()
    {
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Merge"))
    //    {
    //        if(collision.gameObject.GetComponent<Renderer>().materials == GetComponent<Renderer>().materials)
    //        {
    //            if(ID < collision.gameObject.GetComponent<Merge>().ID) { return; }
    //            GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;
    //            Destroy(collision.gameObject);
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision) // ���˽� ���� ������Ʈ�� ���� �� ������ ������Ʈ ����
    {
        if (collision.collider.gameObject.CompareTag("MergeTest"))
        {
            Debug.Log("����");
            Instantiate(Cylinder, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
