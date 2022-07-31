using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : EnemyGameObject
{
    // Start is called before the first frame update

    public float r;

    private int mode;

    //private GameObject range;
    private SpriteRenderer rangeCol;


    void Start()
    {
        base.Start();
        mode = 0;
        timer = 1f;
        resetTimer = 1f;

        base.range = this.transform.GetChild(0).gameObject;
        base.range.transform.localScale = new Vector3(r*2,r*2,0);
        rangeCol = base.range.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void activeBehavior(){

        Vector3 dir = base.player.transform.position-transform.position;

        if(dir.magnitude < r/2 && mode == 0)mode = 1;
        
        if(mode == 0){
            timer = 1f;
            base.activeBehavior();
        }
        else{

            base.rb.velocity = new Vector3(0,0,0);
            
            rangeDisplay();

            if(timer <= 0.1){

                float a = ((float)attack) * ((r-dir.magnitude)/dir.magnitude);
                if(a <= 0)a = 0;
                base.player.GetComponent<Player>().alterHealth(-(int)Mathf.Ceil(a));
                Destroy(this.gameObject);
            }
        }



    }

    private void rangeDisplay(){
        
        float alpha;
        alpha = 1 - timer;
    
        Color texture = new Color(1f,0.6f,0,alpha);

        rangeCol.color = texture;

    }



}
