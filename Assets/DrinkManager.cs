using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    //for in �� �����.
    public GameObject[] Tray = new GameObject[3];
    public GameObject[] FruitList = new GameObject[2];
    public GameObject[] AlcoholList = new GameObject[2];
    public GameObject[] SyrupList = new GameObject[2];

    //GameObject[] Ingrediant = new GameObject[3];
    

    //public List<GameObject> FruitList = new List<GameObject>();
    //public List<GameObject> AlcoholList = new List<GameObject>();
    //public List<GameObject> SyrupList = new List<GameObject>();

    /*
    class A
    {
        class B
        {

        }
    }
    */

    //��� ����Ʈ�� ���� => �� 3���� ���� ���� ������ �ϳ��� �����ϱ� ���ؼ� Ŭ������ �����.
    /*public class Ingrediant
    {
        public List<GameObject> InFruitList = FruitList;
    }*/
    //�� ���տ� �ʿ��� ��� Ŭ������ ���� ������ ����(�ΰ��ӿ��� ���� ������ Ingrediant ����)
    //public Ingrediant ingrediant = new Ingrediant();
    //�׷� ���� Ʈ���̸� �ν��ϰ� ������Ʈ ������ ���Ǹ� �ֱ� ���ؼ� �迭�� ��������.
    //public GameObject[] IngrediantPrefabsList = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        /*
        ingrediant.FruitList.Add("FruitA");
        ingrediant.FruitList.Add("FruitB");
        ingrediant.AlcoholList.Add("AlcoholA");
        ingrediant.AlcoholList.Add("AlcoholB");
        ingrediant.SyrupList.Add("SyrupA");
        ingrediant.SyrupList.Add("SyrupB");
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}