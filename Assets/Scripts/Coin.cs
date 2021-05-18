using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    private coinManager gamePartManager;
    public int partsValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gamePartManager = FindObjectOfType<coinManager>();
            gamePartManager.AddParts(partsValue);
            Destroy(gameObject);
        }
       

    }
}
