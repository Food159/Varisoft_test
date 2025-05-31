using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void GamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
