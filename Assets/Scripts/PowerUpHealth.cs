using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    

    public int HealthBonus = 0;

  
   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.tag == "Player")
       {
          GameObject player = col.gameObject;
          Player playerscript = player.GetComponent<Player>();
          if(playerscript)
          {
            playerscript.health += HealthBonus;
            if(playerscript.health >=3 )
            {
              Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
               Destroy(gameObject);
            }
          }
          
       }
   }

   
}
