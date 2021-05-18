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
        gamePartManager = FindObjectOfType<coinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gamePartManager.AddParts(partsValue);
            Destroy(gameObject);
        }
       

    }
}
