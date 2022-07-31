using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonEnemy : EnemyGameObject
{

    
    int mode;
    float chargeSpeed;

    // Start is called before the first frame update
    void Start()
    {   
        base.Start();
        mode = 0;
        chargeSpeed = 5 + speed;
        //EnemyGameObject = gameObject.GetComponent<EnemyGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    // protected override void passiveBehavior(){


    // }

    protected override void activeBehavior(){
        
        base.resetTimer = 1.25f;
        float chargeTime = 0.5f;
        

        Vector3 dir = base.player.transform.position-transform.position;

        //print("magnitude " + dir.magnitude);
        //print("dir " + 5 * chargeTime);

        print(mode);

        if(timer == resetTimer){

            if(dir.magnitude > chargeSpeed * chargeTime){
                mode = 0;
            }

            else {
                mode = 1;
            }
        }


        if(mode == 0)base.activeBehavior();
        else if(mode == 1)chargeAttack(chargeTime);
        else{
            base.activeBehavior();
            print("something is wrong in goon class");
        }


    }


    private void chargeAttack(float t){
        
        //speed = 5f;

        Vector3 v = base.trackPlayer();

        if(timer < t && timer > 0.01f){
            if(base.rb.velocity.magnitude == 0)base.rb.velocity = v * chargeSpeed;
        }
        else base.rb.velocity = v * 0f;
    }


}


