 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public List<EnemyGameObject> types;
    public int listSize;
    private int n;

    public float spawnIntervals;
    private int spawnedLast;

    private float timer;
    
    private bool active;
    

    // Start is called before the first frame update
    void Start()
    {
        //types = new List<EnemyGameObject>();
        n = types.Count;
        spawnedLast = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(this.transform.childCount < 8)active = true;
        else active = false;

        //print("?TIMER " + timer);

        if(timer >= spawnIntervals && active == true){
            int rand = randomSpawn();

            //print("work please");       

            EnemyGameObject e = Instantiate(types[rand],this.transform.position,Quaternion.Euler(0f,0f,0f)) as EnemyGameObject;
            e.transform.parent = this.transform;

            //GameObject link = GameObject.Instantiate(prefab,new Vector3(x, y, 0), prefab.transform.rotation) as GameObject;
        }

        if(timer >= spawnIntervals)timer = 0;
        timer += Time.deltaTime;
    }


    private int randomSpawn(){

        if(n == 1)return 0;

        int x = spawnedLast;
        while(x == spawnedLast){
            x = Random.Range(0,n-1);
        }
        spawnedLast = x;
        return x;
    }

}
