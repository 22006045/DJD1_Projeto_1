using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoFollow : MonoBehaviour
{
    public Transform targetPlayer;
    public float speed;
    public bool isDead;
    [SerializeField]
    private GameObject PrefabAcido;

    void Start()
    {
        isDead = true;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(targetPlayer == null)
        {
            isDead = false;
        }

    }

    void Update()
    {
        if(isDead == true)
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
            
        }
    }
   
}
