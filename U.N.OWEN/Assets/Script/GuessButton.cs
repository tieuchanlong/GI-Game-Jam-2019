using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessButton : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
