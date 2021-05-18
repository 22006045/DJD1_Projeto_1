using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField] Character      character;
    [SerializeField] RectTransform  healthBar;

    // Update is called once per frame
    void Update()
    {
        float healthPercentage = character.nHealth / (float)character.nMaxHealth;

        healthBar.localScale = new Vector3(healthPercentage, 1, 1);
    }
}
