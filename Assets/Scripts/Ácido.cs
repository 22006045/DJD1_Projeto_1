using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ácido : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Character character = collision.GetComponentInParent<Character>();
        if(character)
        {
            Vector2 hitDirection = character.transform.position - transform.position;

            character.DealDamage(50, hitDirection);
        }
    }
}
