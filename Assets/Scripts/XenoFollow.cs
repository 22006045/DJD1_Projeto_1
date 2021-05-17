using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoFollow : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;



    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(targetPlayer == null)
        {
            
        }

    }

    void Update()
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

    
}
