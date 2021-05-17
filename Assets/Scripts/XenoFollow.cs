using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoFollow : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;
    public bool isDead;
    [SerializeField]
    private GameObject PrefabAcido;

    void Start()
    {
        isDead = true;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(targetPlayer == null)
        {
            isDead = false;
        }

    }

    void Update()
    {
        if(isDead == true)
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
        else
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character != null)
        {
            if (character.IsHostile(faction))
            {
                Vector2 hitDirection = character.transform.position - transform.position;

                character.DealDamage(35, hitDirection);
            }
        }
    }
   protected override void OnDeath()
        {
            if(PrefabAcido)
            {
                Instantiate(PrefabAcido.transform.position, transform.rotation);
            }
        
        }  
}
