using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneToLoad; //to check which scene to load

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
