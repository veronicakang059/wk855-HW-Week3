using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;
    public int CurrentLevel;
    private int score = 0;
    
    const string DIR_LOGS = "/Logs";
    const string FILE_SCORES = DIR_LOGS + "/highScores.txt";
    const string PREF_KEY_HIGH_SCORE = "hsKey";
    private const string FILE_ALL_SCORES = DIR_LOGS + "/allScores.csv";
    string FILE_PATH_HIGH_SCORE;
    string FILE_PATH_ALL_SCORE;
    public int Score
    {
        get { return score;}
        set
        {
            score = value;

            //Debug.Log("someone set the score!");
            if (score > Highscore)
            {
                Highscore = score;
            }
            
            string fileContents = "";
            if (File.Exists(FILE_PATH_ALL_SCORE)){
                fileContents = File.ReadAllText(FILE_PATH_ALL_SCORE);
            }
            fileContents += score + ",";
            File.WriteAllText(FILE_PATH_ALL_SCORE, fileContents);
        }
    }

    public int highScore = -1;

    public int Highscore
    {
        get
        {
            if (highScore < 0)
            {
                //highScore = PlayerPrefs.GetInt(PREF_KEY_HIGH_SCORE, 2);
                if (File.Exists(FILE_PATH_HIGH_SCORE))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORE);
                    highScore = Int32.Parse(fileContents);
                }
                else
                {
                    highScore = 3;
                }
            }
            return highScore;
        }
        set
        {
            highScore = value;
            Debug.Log("high score is updated!");
            //Debug.Log("filePath:" + FILE_PATH_HIGH_SCORE);
            PlayerPrefs.SetInt(key:PREF_KEY_HIGH_SCORE, highScore);
            File.WriteAllText(FILE_PATH_HIGH_SCORE,highScore+"");

            if (!File.Exists(FILE_PATH_HIGH_SCORE))
            {
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
                //File.Create(FILE_PATH_HIGH_SCORE);
            }
        }
    }

    public int targetScore = 3;
    public int currentLevel = 0;
    public Text text;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       //PlayerPrefs.DeleteKey("hsKey");
       FILE_PATH_HIGH_SCORE = Application.dataPath + FILE_SCORES;
       FILE_PATH_ALL_SCORE = Application.dataPath + FILE_ALL_SCORES;
    }

    // Update is called once per frame
    private void Update()
    {
        
        text.text = "Level:"+ currentLevel+
                    "\nScore:" + GameManager.instance.score + " Target:" + targetScore +
                    "\nHighestScore:" + Highscore;
        if (score == targetScore)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            targetScore *= 2;
        }
    }
}