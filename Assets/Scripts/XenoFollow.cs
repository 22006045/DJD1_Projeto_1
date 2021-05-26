using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoFollow : Character
{
    public Transform targetPlayer;
    public float speed;
    private bool isDead;
    [SerializeField]
    private GameObject PrefabAcido;
    [SerializeField]
    private float range;
    

    protected override void Start()
    {
        isDead = false;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        base.Start();

    }

    protected override void Update()
    
    {
        if(targetPlayer == null)
        {
            isDead = true;
           
        }
        
        if(isDead == false)
        {   
            if(Vector3.Distance(transform.position, targetPlayer.transform.position) < range)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

                if(transform.position.x < targetPlayer.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, -1);
                }

                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

        }
        else
        {
            targetPlayer = null;
        }
        base.Update();
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character != null && collision.gameObject.name.Equals("Player"))
        {
            
            Vector2 hitDirection = character.transform.position - transform.position;

            character.DealDamage(1, hitDirection);
            
        }

    }

    protected override void OnDeath()
    {
        if(PrefabAcido)
        {
            Instantiate(PrefabAcido, transform.position, transform.rotation);
        }
        
    }  
    
}
