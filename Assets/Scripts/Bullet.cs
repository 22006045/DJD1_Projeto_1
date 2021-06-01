using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    private GameObject Player;
    private GameObject Xeno;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Xeno = GameObject.Find("Xeno");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D (Collision2D bullet)
    {   
        if(bullet.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            
        }




        if(bullet.gameObject.tag == "Enemy")
        {
            Debug.Log("You were shot");
            Vector2 hitDirection = Player.transform.position - transform.position;
            bullet.gameObject.GetComponent<XenoFollow>().DealDamage(1,hitDirection);
            Destroy(gameObject);
        }
        
    }
}

