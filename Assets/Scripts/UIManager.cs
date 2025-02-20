using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI mainText;
    void Start()
    {
        if (mainText == null)
            Debug.LogError("main text is null");

        if (scoreText == null)
            Debug.LogError("score text is null");
    }

    // Update is called once per frame
    public void ToMain()
    {
        mainText.gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
        
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
