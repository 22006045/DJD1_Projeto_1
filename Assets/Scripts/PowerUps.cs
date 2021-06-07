using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    GameObject Player;

    public int HealthBonus = 1;

  void Start()
  {
    Player.GetComponent<Character>();
  }
   void OnTriggerEnter2D(Collider2D col)
   {
       if(col.tag == "Player")
       {
           
       }
   }

   public void HealthPowerUp(int healthBonus)
   {
       
   }
}
