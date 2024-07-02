using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    
    public void ExitToMenu()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
