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

    public void loadnextGameScene()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void loadMainMenu()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        sceneloader.SetTrigger("start");

        yield  return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
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
