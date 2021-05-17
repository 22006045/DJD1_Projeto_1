using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xeno : Character
{
    [SerializeField]
    private float       moveDir = -1.0f;
    [SerializeField]
    private float       moveSpeed = 100.0f;
    [SerializeField]    
    private Transform   wallCheckObject;
    private Transform targetPlayer;
  

    protected override bool knockbackOnHit => false;

    // Update is called once per frame
    protected override void Update()
    {
        if (!isDead)
        {
            bool hasGround = IsGround();

            Collider2D wallCollider = Physics2D.OverlapCircle(wallCheckObject.position, groundCheckRadius, groundCheckLayer);

            bool hasWall = (wallCollider != null);

            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
            if ((!hasGround) || (hasWall))
            {
               moveSpeed = 0;
            

                if(transform.position.x < targetPlayer.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, -1);
                }

                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            Vector2 currentVelocity = rb.velocity;

            currentVelocity.x = moveDir * moveSpeed;

            if (canMove)
            {
                rb.velocity = currentVelocity;
            }

            TurnTo(currentVelocity.x);
        }

        base.Update();
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

    

   
}
