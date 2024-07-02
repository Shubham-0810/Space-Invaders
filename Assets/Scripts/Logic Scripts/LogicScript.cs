using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public BGScrollScript BgScroll;
    public GameObject BossEnemy;
    public GameObject EnemySpawner;
    private int HighestScore = 10;
    public int playerHealth = 10;
    public int PlayerHealthChanger = 1;
    public int playerScore = 0;
    public Text scoreText;
    public GameObject PauseMenuUI;
    public GameObject GameOverScreenUI;
    private PauseScreenScript PauseScreenScript;
    // Start is called before the first frame update
    void Start()
    {
        BgScroll = GameObject.FindGameObjectWithTag("BgScrollTag").GetComponent<BGScrollScript>();
        PauseScreenScript = PauseMenuUI.GetComponent<PauseScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        if (playerScore >= HighestScore)
        { 
            BgScroll.ScrollSpeed = 0f;
            EnemySpawner.SetActive(false);
            BossEnemy.SetActive(true);
        }

    }
    public void Reduce_Health()
    {
        playerHealth -= PlayerHealthChanger ;
        Debug.Log(playerHealth);
    }

   public void RestartGame()
    {
        GameOverScreenUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseScreenScript.PressResume();
    }
}
