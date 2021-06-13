using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2 : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    private coinManager CheckParts;

    private GameObject Player;

    public BoxCollider2D collider;
    
    bool isOpen = false;

    public GameObject popUp;

    

    private Animator open_door;

    public AudioSource DoorSound;


   void Start()
   {
       Player = GameObject.Find("Player");
       CheckParts = GameObject.Find("PartsManager").GetComponent<coinManager>();
       popUp.SetActive(false);
      
       open_door = GetComponent<Animator>();
       DoorSound = GetComponent<AudioSource>();

   }
    void OnTriggerEnter2D(Collider2D col)
    {
       
       if(col.gameObject.tag == "Acid")
        {
            Debug.Log("I GOT ACID ON ME EWWWWWW");
            isOpen = true;
            
           
        }
        if(col.gameObject.name.Equals("Player"))
        {   
            popUp.SetActive(true);
            Debug.Log("I see you/n YOU NEED MORE PARTS");
            isOpen = true;
           
        }
        if(isOpen == true && CheckParts.parts >=6)
        {
            open_door.SetBool("open",true);
            GetComponent<BoxCollider2D>().enabled = false;
            DoorSound.Play();
        
        }
       
       
        if(isOpen == true && col.gameObject.tag == "Acid" )
        {

            GetComponent<BoxCollider2D>().enabled = false;

        }
        
            

    }
    void OnTriggerExit2D(Collider2D col)
    {
        popUp.SetActive(false);
    }
   
}

