using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoFollow : MonoBehaviour
{
    public Transform targetPlayer;
    public float speed;
    private bool isDead;
    [SerializeField]
    private GameObject PrefabAcido;

    void Start()
    {
        isDead = false;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(targetPlayer == null)
        {
            isDead = true;
           
        }

    }

    void Update()
    {
        if(isDead == false)
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
        else
        {
            targetPlayer = null;
        }
    }
   
}
