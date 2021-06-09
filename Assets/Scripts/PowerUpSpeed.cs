using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public int SpeedBonus ;
    private float timer;
    private bool Speeding;
    


  void Start()
  {
    timer = 0;
    Speeding = false;
    SpeedBonus = 0;
  }

  void Update()
  {
    if(Speeding)
    {
      timer += Time.deltaTime;
      if(timer >= 3)
      {
        SpeedBonus = 0;
        timer = 0;
        Speeding = false;
      } 

    }
  }
  
  void OnTriggerEnter2D(Collider2D col)
   {
       if(col.tag == "Player")
       {
          Speeding = true;
          SpeedBonus = 300;
          GameObject player = col.gameObject;
          Player playerscript = player.GetComponent<Player>();
          playerscript.moveSpeed = SpeedBonus;
          Destroy(gameObject);

       }
   }
}
