using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0, 10)]float time = 1f;
    [SerializeField] float pointsPerBlock = 5f;
    [SerializeField] float score = 0f;
    [SerializeField] TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = time;
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score += pointsPerBlock;
    }
    public void ResetGame()
    {
        Destroy(gameObject); 
    }
}
