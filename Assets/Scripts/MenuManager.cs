using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu_Panel;
    public GameObject LevelSelection_Panel;
    public void PlayButton()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();

        SceneManager.LoadScene(2);
    }
    public void SelectLevel()
    {
        LevelSelection_Panel.SetActive(true);

        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();
    }
    public void BackButton()
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();

        LevelSelection_Panel.SetActive(false);
        
    }

    public void LevelSelection(int levelno)
    {
        SoundManager.Instance.SFX_Source.clip = SoundManager.Instance.Button_Sound;
        SoundManager.Instance.SFX_Source.Play();

        PlayerPrefs.SetInt("levelno", levelno);

        SceneManager.LoadScene(2);
    }
    public void LogOut()
    {
        PlayerPrefs.SetInt("LogedIn", 0);
        SceneManager.LoadScene(0);
    }
}
