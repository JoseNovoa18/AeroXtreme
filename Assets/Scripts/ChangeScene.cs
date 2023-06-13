using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void ChangeToMainScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
