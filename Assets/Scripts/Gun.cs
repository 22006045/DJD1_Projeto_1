using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform   barrelTip;
    [SerializeField]
    private GameObject  bullet;

    private Vector2 mousePos;
   
    private float fireRate = 0.5f;
    
    private float nextFire = 0f;

    private bool TakeAim = false;
    
    Vector2 myPos;
    Vector2 direction;
void Start ()
{
    
   
}

private void Update()
{
    while(Input.GetMouseButtonDown(1))
    {
        TakeAim = true;
    }

    if(TakeAim == true)
    {
        if(Input.GetMouseButtonDown(0))
            {
               
                Debug.Log("SHOT THE BULLET");
                FireBullet();
            }
    }
    
}



 void FireBullet()
        {
            if(Time.time > nextFire)
            {
                Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
                Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                nextFire = Time.time + fireRate;
                GameObject newBullet = (GameObject)Instantiate(bullet, barrelTip.position , Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity = direction * 200f;
            }
            
        }



}
