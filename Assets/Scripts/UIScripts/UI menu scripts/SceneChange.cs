using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject credits;
    public Animator sceneloader;
    public float transitionTime = 1f;

    private void Start()
    {
        credits.SetActive(false);
    }

    public void MoveToScene(int sceneID)
    {
        StartCoroutine(LoadGame(sceneID));
    }

    IEnumerator LoadGame(int sceneID)
    {
        // Play transition animation
        if (sceneloader != null)
        {
            sceneloader.SetTrigger("Start");
        }

        // Wait for transition time
        yield return new WaitForSeconds(transitionTime);

        // Load the game scene
        SceneManager.LoadScene(sceneID);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
