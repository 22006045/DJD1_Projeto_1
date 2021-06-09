using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : Bullet
{
    private GameObject Player;
    private GameObject Xeno;
    public int damageBoost;

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
    void OnCollisionEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Vector2 hitDirection = Player.transform.position - transform.position;
            col.gameObject.GetComponent<XenoFollow>().DealDamage(5 + damageBoost,hitDirection);
            Destroy(gameObject);
        }
    }
}
