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
        PlayerPrefs.SetInt("Score", currentScore); // 점수를 저장

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore); // 최고 점수 업데이트
        }

        PlayerPrefs.Save();
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
