using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour

{
    public bool TimerOn;
    Rigidbody2D rb;
    private GameObject Player;
    private GameObject Xeno;
    private GameObject trap;
    private float delay = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D> ();
        Player = GameObject.Find("Player");
        Xeno = GameObject.Find("Xeno");    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
            rb.isKinematic = false;
            
        if(col.gameObject.name.Equals("Xeno"))
            rb.isKinematic = false;
            
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        
        if(col.gameObject.name.Equals("Player")) 
        {
            Vector2 hitDirection = Player.transform.position - transform.position;
            Player.GetComponent<Player>().DealDamage(2,hitDirection);
          
        }  

        if(col.gameObject.tag == "Enemy" )
        {
            Debug.Log("OLAAAA");
            Vector2 hitDirection = Player.transform.position - transform.position;
            col.gameObject.GetComponent<XenoFollow>().DealDamage(2,hitDirection);
        }  
        
          
    }
}