using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public int SpeedBonus = 100;

  
   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.tag == "Player")
       {
          GameObject player = col.gameObject;
          Player playerscript = player.GetComponent<Player>();
          if(playerscript)
          {
            playerscript.moveSpeed += SpeedBonus;
            Destroy(gameObject);
          }
       }
   }
}
