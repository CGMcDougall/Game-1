using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitRange : MonoBehaviour
{

    private EnemyGameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject.GetComponent<EnemyGameObject>();
        if(parent.transform.localScale.magnitude <= transform.localScale.magnitude){
            transform.localScale = parent.transform.localScale * 1.1f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D c){

        if(c.tag == "Player"  && c.isTrigger == false && parent.getRangeActive() == true){
            c.GetComponent<Player>().alterHealth(-parent.getAttack());
        }

    }

}
