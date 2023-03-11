using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;

    public TMP_Text scoreText;
    public bool isPlay;

    public static GameManager _instance;
    public GameObject GameOverPanal;
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;
    public Button resetButton;
    public Camera mainCamera;
    public Image Background;
    public Color[] colorToChange;
    public int randomIndex;

    public GameObject StartGame;
    public Button startGameButton;
    public TMP_Text BestScoreText;



    /*    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<GameManager>();
                    singleton.name = typeof(GameManager).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singleton);
                }
            }

            return _instance;
        }
    }*/


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        /*else
        {
            Destroy(gameObject);
        }*/
        randomIndex = Random.Range(0,colorToChange.Length);
        ChangeColor();
        isPlay = false;
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        //StartGame.SetActive(true);
        GameOverPanal.SetActive(false);
        resetButton.onClick.RemoveAllListeners();
        resetButton.onClick.AddListener(RestartLevel);
        currentScoreText.text = PlayerPrefs.GetInt("Score").ToString();

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        startGameButton.onClick.RemoveAllListeners();

        startGameButton.onClick.AddListener(Play);
        if(PlayerPrefs.GetInt("HighScore") != null)
        {
            BestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            BestScoreText.text = "0";
        }
        


    }
    private void Update()
    {
        ApplyColor();
    }

    public void AddScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }
    public void GameOver() {
        StartCoroutine(GameOverIE());
    }
    IEnumerator GameOverIE()
    {

        yield return new WaitForSeconds(1f);

        //FindObjectOfType<AudioManager>().Play("GameOver");

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);

        currentScoreText.text = PlayerPrefs.GetInt("Score").ToString();

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        GameOverPanal.SetActive(true);

        isPlay = false;


    }


    public void RestartLevel()
    {
        FindObjectOfType<AudioManager>().Play("Coint");
        SceneManager.LoadScene("GamePlay");
        
    }
    void ApplyColor()
    {
        if(score >= 2)
        {
            ChangeColor();
        }
        else if(score == 5) { ChangeColor(); }
    }

    public void ChangeColor() {

        mainCamera.backgroundColor = colorToChange[randomIndex];
        Background.color = colorToChange[randomIndex];

    }
    public void Play()
    {

        isPlay = true;
        StartGame.SetActive(false);
    }
}

