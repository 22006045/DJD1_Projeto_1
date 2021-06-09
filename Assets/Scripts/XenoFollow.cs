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
    public float range;
    private Animator enemyWalk;
    

    protected override void Start()
    {
        isDead = false;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyWalk = GetComponent<Animator>();
        maxHealth = 20;
        base.Start();
        
    }

    protected override void Update()
    
    {
       
       if(maxHealth <= 19)
        {
            range += 500f;
        }

        if(targetPlayer == null)
        {
            isDead = true;
        }
        
       
        if(isDead == false)
        {   
            if(Vector3.Distance(transform.position, targetPlayer.transform.position) < range)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                enemyWalk.SetBool("Walk",false);

                if(transform.position.x < targetPlayer.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, -1);
                    enemyWalk.SetBool("Walk",false);
                }

                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    enemyWalk.SetBool("Walk",false);
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
   
