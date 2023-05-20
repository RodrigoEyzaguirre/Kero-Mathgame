using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public string sceneToLoad; //to check which scene to load

    public void NextScene()
    {
        StartCoroutine(WaitNext());
    }
    IEnumerator WaitNext()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void StartScene()
    {
        StartCoroutine(WaitStart());
    }
    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }

}
