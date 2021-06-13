using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform   barrelTip;
    [SerializeField]
    private GameObject  bullet;
    [SerializeField]
    private Transform  GunPos;

    private Vector2 mousePos;
   
    private float fireRate = 0.5f;
    
    private float nextFire = 0f;

    private Animator PlayerAim;

    private Animator PlayerShoot;

    AudioSource gunshot;
    
    Vector2 myPos;
    Vector2 direction;
void Start ()
{
    gunshot = GetComponent<AudioSource>();
    PlayerAim = GetComponent<Animator>();
    PlayerShoot = GetComponent<Animator>();

    
}

private void Update()
{
    if(Input.GetMouseButton(1))
    {
        
        PlayerAim.SetBool("Aim",true);
        Debug.Log("I HAVE PRESSED IT");
         if(Input.GetMouseButtonDown(0))
            {
                PlayerShoot.SetBool("Shoot",true);
                Debug.Log("SHOT THE BULLET");

                FireBullet();
                {
                    gunshot.Play();
                }
                
            }
            else
            PlayerShoot.SetBool("Shoot",false);
    }
    else
        PlayerAim.SetBool("Aim", false);
   
}



 void FireBullet()
        {
            if(Time.time > nextFire)
            {
                
                gunshot.Play();
                Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
                Vector2 myPos = new Vector2(GunPos.position.x,GunPos.position.y );
                Vector2 direction = target - myPos;
                direction.Normalize();
                nextFire = Time.time + fireRate;
                GameObject newBullet = (GameObject)Instantiate(bullet, barrelTip.position , Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity = direction * 200f;
            }
            
        }



}
