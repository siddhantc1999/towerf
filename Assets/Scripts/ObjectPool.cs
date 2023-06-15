using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] int poolLength;
    public List<GameObject> enemylist;
    //turn this on for prev state
    [SerializeField] Vector3 startposition;
    public List<Transform> instantiatingpoints=new List<Transform>();
    public int j;
    private void Awake()
    {
        enemylist = new List<GameObject>();
      
        for (int i=0;i<poolLength;i++)
        {
            GameObject enemy = Instantiate(enemyprefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            enemylist.Add(enemy);
       
            enemy.SetActive(false);
        }

        instantiatingpoints = Levelinstantiatedestination.instance.getinstantiatepoints;
    }
    // Start is called before the first frame update
    void Start()
    {
      
        StartCoroutine(EnemyInstantiate());    
    }

   IEnumerator EnemyInstantiate()
    {
        while(true)
        {


            EnableObjectPool();
            //for (int j = 0; j < poolLength; j++)
            //{
            //    //i value is incrementing itself
            //    Debug.Log("the value of j "+j);
            //    //Debug.Log("gameobject active " + enemylist[i].activeInHierarchy);
            //    if (enemylist[j].activeInHierarchy == false)
            //    {

            //        //Debug.Log("the value of i "+i);
            //        enemylist[j].SetActive(true);
            //        //enemylist[j].transform.position = startposition;
            //        //return;
            //        yield return new WaitForSeconds(1f);
            //    }
            //}


            yield return new WaitForSeconds(1f);
        }
    }

    private void EnableObjectPool()
    {
        startposition = instantiatingpoints[UnityEngine.Random.Range(0, instantiatingpoints.Count)].transform.position;
     /*   Debug.Log("the start position in object pool "+startposition);*/
        for (int j = 0; j < poolLength; j++)
        {
            //i value is incrementing itself
            //Debug.Log("the value of j "+j);
            //Debug.Log("gameobject active " + enemylist[i].activeInHierarchy);
            if (enemylist[j].activeInHierarchy == false)
            {
                enemylist[j].transform.position = startposition;
                //Debug.Log("the value of j " + j);
                enemylist[j].SetActive(true);
           
               

                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
