using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour
{
    [SerializeField]
    AudioSource coinSound;


    public Text partText;
    public int parts;
    
    // Start is called before the first frame update
    void Start()
    {
        partText.text = "Parts: " + parts;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddParts(int numberOfParts)
        {
           parts += numberOfParts;
           partText.text = "Parts: " + parts;

           coinSound.pitch = Random.Range(1.0f, 1.2f);
            coinSound.Play();
        }
}
