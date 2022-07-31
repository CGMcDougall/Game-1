using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{   

    public GameObject player;
    public Camera cam;

    private bool active;

    private SpriteRenderer render;


    //same as final keyword
    private float timer = 0.5f;
    private float fire = 0.3f;
    private Color texture; 
    


    // Start is called before the first frame update
    void Start()
    {
        active = false; 
        texture = new Color(0f,0.95f,1f,.5f);
        render  = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {       
        location();

        Active();

    }

    private void location(){

        float rad = player.transform.localScale.x/2;
        
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos-player.transform.position;
     

        float deg = (Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg) + 90;

        // print("Degrees : " + deg);
        // print("dir : " + dir);

        dir = dir.normalized;

        transform.rotation = Quaternion.Euler(0,0,deg);

        this.transform.position = player.transform.position + (dir *rad);

    }

    private void Active(){
        
        

        if(Input.GetButtonDown("Fire1") && timer >= 0.5f){
            active = true;
            print("FIRE");
        }

        if(timer <= 0.3f)active = false;
        if(timer < 0)timer = 0.5f;
        

        if(active){
            //temp
            print("should be visible");
            render.color = texture;
            
        }

        else{
            render.color = new Color(0,0,0,0);
        }

        if(timer != 0.5f || active == true)timer -= Time.deltaTime;

        //print(timer);
    }


    private void OnTriggerEnter2D(Collider2D c){
    
        if(c.tag == "Enemy" && c.isTrigger == false && active == true){
            Destroy(c.gameObject); 
        }

    }

    private void OnTriggerStay2D(Collider2D c){
    
        if(c.tag == "Enemy" && c.isTrigger == false && active == true){
            Destroy(c.gameObject); 
        }

    }


}
