using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{

    int ID;
    public GameObject OrangeCup;
    
    void Start()
    {
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision) // ���˽� ���� ������Ʈ�� ���� �� ������ ������Ʈ ����
    {
        if (collision.collider.gameObject.CompareTag("Object"))
        {
            Debug.Log("����");
            Instantiate(OrangeCup, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
