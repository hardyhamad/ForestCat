using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera maincam;
    [Space]
    public TMP_Text Current_Coins_Text;
    public TMP_Text LevelNo_Text;
    public TMP_Text Lives_Text;
    public int Coins_Count;
    public int Lives_Count=3;
    public int LevelNo;

    public GameObject LevelfinishPanel;
    public GameObject LevelfailPanel;
    public GameObject[] Levels;

    public Transform SpawnPoint;
    public GameObject player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Current_Coins_Text.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        Lives_Count = 3;
        //PlayerPrefs.SetInt("LevelSelected", PlayerPrefs.GetInt("levelno",1));
        LevelNo = PlayerPrefs.GetInt("levelno", 1);
        LevelNo_Text.text = "Level " + LevelNo.ToString();
        Levels[LevelNo - 1].SetActive(true);
        Coins_Count = 0;
    }

    // Update is called once per frame
    public void CoinsUpdate()
    {
        Coins_Count += 1;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + 10);
        Current_Coins_Text.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }
    public void LivesUpdate()
    {
        
        Lives_Count -= 1;
        Lives_Text.text = Lives_Count.ToString();
        CheckLevelFail();
    }
    public void CheckLevelFail()
    {
        if (Lives_Count <= 0)
        {
            SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Level_Fail_Sound;
            SoundManager.Instance.SFX_Source.Play();

            LevelfailPanel.SetActive(true);
            player.SetActive(false);
            Lives_Count = 3;

        }
        else
        {
            player.transform.position = SpawnPoint.position;

        }
    }
    public void LevelComplete()
    {
        LevelfinishPanel.SetActive(true);

    }
    public void HomeScreen()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play(); if (PlayerPrefs.GetInt("levelno") >= 3)
        {        
            PlayerPrefs.SetInt("levelno", 1);

        }
        else
        {
            PlayerPrefs.SetInt("levelno", PlayerPrefs.GetInt("levelno", 1) + 1);

        }

        SceneManager.LoadScene(2);

    }
    public void Replay()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();
        SceneManager.LoadScene(2);

    }

    bool postprocessing = false;
    public void PostProcessing()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();
        if (!postprocessing)
        {
            maincam.GetComponent<PostProcessLayer>().enabled = true;
            postprocessing = true;
        }
        else
        {
            maincam.GetComponent<PostProcessLayer>().enabled = false;
            postprocessing = false;

        }
    }

   
}
