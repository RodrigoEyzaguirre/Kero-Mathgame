using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioSource btnSound;

    private static UISound instance = null;
    public static UISound Instance
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
    }
    public void BtnSound()
    {
        btnSound.Play();
    }
}
