using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float accel;
    private int hp;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 15;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        print(hp);
    }   


    void PlayerMovement(){
        
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(xMove,yMove,0);
        movement = movement.normalized;
        rb.velocity = movement * speed;

    }

    //use negative numbers for hp loss
    public void alterHealth(int x){
        hp += x;
    }

    // void OnCollisionEnter2D(Collision2D c)
    // {
    //     if (c.gameObject.tag == "Enemy"){

    //         this.hp -=c.gameObject.GetComponent<EnemyGameObject>().getAttack();

    //     }
        
    // }

}
