using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject PauseButtonUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PressPause()
    {
        PauseButtonUI.SetActive(false);
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }
    public void PressResume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        PauseButtonUI.SetActive(true);
    }
}
