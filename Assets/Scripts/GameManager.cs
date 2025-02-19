using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static GameManager gameManager;
    UIManager uiManager;
    public UIManager UIManager {  get { return uiManager; } }
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.ToMain();
        uiManager.UpdateScore(0);
    }

    public void RestartGame()
    {
        uiManager.ToMain();
      
    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            SceneManager.LoadScene("MiniGame");
      
    }
}
