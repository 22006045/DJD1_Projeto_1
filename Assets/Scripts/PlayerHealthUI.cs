using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[]    health;

    Player player;


    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        int nHealth = 0;

        if(player != null)
        {
            nHealth = player.nHealth;
        }

        for (int i = 0; i < nHealth; i++)
        {
            health[i].SetActive(true);
        }

        for (int i = nHealth; i < health.Length; i++)
        {
            if(i >= 0)
                health[i].SetActive(false);
        }
    }
}
