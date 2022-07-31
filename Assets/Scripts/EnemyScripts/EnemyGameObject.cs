using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameObject : MonoBehaviour
{


    protected GameObject player;
    protected Rigidbody2D rb;

    protected GameObject range;

    //timer variables
    protected float timer;
    protected float resetTimer;
    protected bool rangeActive;

    //Enenmy Stats
    public int attack;
    public float hp;
    public float speed;
    protected bool aggro;
    

    // Start is called before the first frame update
    protected void Start()
    {   
        timer = 1f;
        resetTimer = 1.5f;

        attack = 3;
        hp = 5f;

        aggro = false;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        range = this.transform.GetChild(0).gameObject;
        rangeActive = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        if(aggro)activeBehavior();
        else passiveBehavior();


        timer -= Time.deltaTime;
        if(timer <= 0f)timer = resetTimer;
    }

    

    protected Vector3 trackPlayer(){

        Vector3 dir = player.transform.position-transform.position;
        dir = dir.normalized;

        return dir;

    }


    virtual protected void passiveBehavior(){
        if(timer > 0.5f && rb.velocity.magnitude == 0){
            float r = Random.Range(0,3);
            switch(r)
            {
                case 0:
                    rb.velocity = new Vector3(-1*speed,0,0);
                    break;
                case 1:
                    rb.velocity = new Vector3(speed,0,0);
                    break;
                case 2:
                    rb.velocity = new Vector3(0,-1*speed,0);
                    break;
                case 3:
                    rb.velocity = new Vector3(0,speed,0);
                    break;
                default:
                    print("Something went wrong");
                    break;
            }   
        }
        
        else if(timer < 0.5f)rb.velocity = new Vector3(0,0,0);
        
        

       

    }

    virtual protected void activeBehavior(){
        Vector3 v = trackPlayer();
        rb.velocity = v * speed;
        rangeActive = true;
    }

    protected void OnTriggerEnter2D(Collider2D c){

        if(c.tag == "Player"  && c.isTrigger == false){
            aggro = true;  
            timer = resetTimer;
        }

    }


    public int getAttack(){
        return attack;
    }

    public float getHealth(){
        return hp;
    }

    public bool getRangeActive(){
        return rangeActive;
    }



}
