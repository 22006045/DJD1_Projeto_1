using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu(float time)
    {
        StartCoroutine(BackToMainMenuCR(time));
    }
    IEnumerator BackToMainMenuCR(float time)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < time)
        {
            yield return null;

            elapsedTime += Time.deltaTime;

        }
        SceneManager.LoadScene("Main Menu");
    }
}
