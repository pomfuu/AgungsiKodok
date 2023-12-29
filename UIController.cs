using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this; 
    }

    public Image[] heartIcons;

    public Sprite heartFull, heartEmpty;
    public TMP_Text livesText, collectibleText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public string mainMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void UpdateHealthDisplay(int health, int maxHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;
            /* if(health <= i)
            {
                heartIcons[i].enabled = false;
            } */
            if(health > i)
            {
                heartIcons[i].sprite = heartFull;
            }
            else
            {
                heartIcons[i].sprite = heartEmpty;
                if(maxHealth <= i)
                {
                    heartIcons[i].enabled = false;
                }
            }
        }

    }
        public void UpdateLivesDisplay(int currenLives)
        {
            livesText.text = currenLives.ToString();
        }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        //Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }

    public void UpdateCollect(int amount)
    {
        collectibleText.text = amount.ToString();
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I Quit");
    }
}
