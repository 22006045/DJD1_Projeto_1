using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    private coinManager CheckParts;

    private GameObject Player;

    public BoxCollider2D collider;
    
    bool isOpen = false;

   void Start()
   {
       Player = GameObject.Find("Player");
       CheckParts = GameObject.Find("PartsManager").GetComponent<coinManager>();
       

   }
    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.name.Equals("PrefabAcido1"))
        {
            Debug.Log("I GOT ACID ON ME EWWWWWW");
            isOpen = true;
           
        }
        if(col.gameObject.name.Equals("Player"))
        {
            Debug.Log("I see you/n YOU NEED MORE PARTS");
            isOpen = true;
           
        }
        if(isOpen == true && CheckParts.parts >=1)
        {
            
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
   
}
