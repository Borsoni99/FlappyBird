using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour

{
    [SerializeField]
    private GameObject[] characters;

    public static GameManager instance;

    public UnityEngine.UI.Slider volumeSlider;

    private AudioSource audioSource;

    private int _charIndex = 0;

    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = instance.GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            Instantiate(characters[CharIndex]);
        }
    }
    public void PlayerDied()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnVolumeSliderChanged(float newVolume)
    {   
        Debug.Log("setting volume to "+ newVolume);
        audioSource.volume = newVolume;
    }
}
