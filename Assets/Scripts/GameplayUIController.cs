using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
