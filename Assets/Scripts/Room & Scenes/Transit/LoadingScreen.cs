using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private int index;

    public GameObject loadingScreen;
    public GameObject hideObject;
    public GameObject animObject;
    public Slider bar;
    public TMP_Text text;

    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadRoom()
    {
        loadingScreen.SetActive(true);
        hideObject.SetActive(false);
        animObject.GetComponent<Animator>().enabled = true;
        //SceneManager.LoadScene(index + 1);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index + 1);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                text.enabled = true;
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
