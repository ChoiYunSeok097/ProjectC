using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class _UI_UIManager : MonoBehaviour
{
    public bool pauseBtn = false;       //pause
    public bool soundBtn = false;

    public bool speedX2 = false;

    public GameObject pauseBg;
    public GameObject soundBg;

    public _Data_GameManager gameManager;

    public AudioMixer masterMixer;
    public AudioMixer BGMMixer;
    public AudioMixer SFXMixer;
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;

    public void PauseBtn()
    {
        if (pauseBtn)
        {
            Time.timeScale = 1;
            pauseBtn = false;
            pauseBg.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseBtn = true;
            pauseBg.gameObject.SetActive(true);

            MasterSlider.value = AudioListener.volume;
            float value;
            BGMMixer.GetFloat("BGM", out value);
            BGMSlider.value = value;
            SFXMixer.GetFloat("SFX", out value);
            SFXSlider.value = value;
        }
    }

    public void SoundBtn()
    {
        if (soundBtn)
        {
            Time.timeScale = 1;
            soundBtn = false;
            soundBg.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            soundBtn = true;
            soundBg.gameObject.SetActive(true);
        }
    }

    public void SpeedBtn()
    {
        if (!speedX2)
        {
            speedX2 = true;
            Time.timeScale = 2f;
        }
        else
        {
            speedX2 = false;
            Time.timeScale = 1f;
        }

    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseBg.gameObject.SetActive(false);
    }

    public void MasterSoundSet()
    {
        float sound = MasterSlider.value;

        if (sound == -40f) AudioListener.volume = -80;
        else AudioListener.volume = sound;

    }
    public void BGMSoundSet()
    {
        float sound = BGMSlider.value;

        if (sound == -40f) BGMMixer.SetFloat("BGM", -80);
        else BGMMixer.SetFloat("BGM", sound);

    }
    public void SFXSoundSet()
    {

        float sound = SFXSlider.value;

        if (sound == -40f) SFXMixer.SetFloat("SFX", -80);
        else SFXMixer.SetFloat("SFX", sound);

    }

    public void Backspace()
    {
        SceneManager.LoadScene("MainLobby");
    }
}
