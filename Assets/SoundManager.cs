using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    private string sceneName;

    public AudioSource startMusic;
    public AudioSource gameMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    public static SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(transform.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);

        startMusic.enabled = false;
        gameMusic.enabled = false;
        winMusic.enabled = false;
        loseMusic.enabled = false;
    }

    private void Update()
    {
        SetScene();
        switch(sceneName)
        {
            case "Game":
                startMusic.enabled = false;
                gameMusic.enabled = true;
                winMusic.enabled = false;
                loseMusic.enabled = false;
                break;
            case "Win":
                startMusic.enabled = false;
                gameMusic.enabled = false;
                winMusic.enabled = true;
                loseMusic.enabled = false;
                break;
            case "Lose":
                startMusic.enabled = false;
                gameMusic.enabled = false;
                winMusic.enabled = false;
                loseMusic.enabled = true;
                break;
            default:
                startMusic.enabled = true;
                gameMusic.enabled = false;
                winMusic.enabled = false;
                loseMusic.enabled = false;
                break;
        }
    }

    void SetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

}
