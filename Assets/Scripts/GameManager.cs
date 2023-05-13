using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void EndGame()
    {
        // Reload the current scene when the game ends
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
