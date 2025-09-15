using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Token: 0x02000015 RID: 21
public class Menu : MonoBehaviour
{
    // Token: 0x06000051 RID: 81 RVA: 0x00003774 File Offset: 0x00001974
    public void PlayGame()
    {
        this.swordAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Token: 0x06000052 RID: 82 RVA: 0x000037A3 File Offset: 0x000019A3
    public void QuitGame()
    {
        this.swordAudio.Play();
        Application.Quit();
    }

    // Token: 0x06000053 RID: 83 RVA: 0x000037B8 File Offset: 0x000019B8
    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }

    // Token: 0x06000054 RID: 84 RVA: 0x000037CC File Offset: 0x000019CC
    public void PauseGame()
    {
        this.swordAudio.Play();
        this.pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Token: 0x06000055 RID: 85 RVA: 0x000037F3 File Offset: 0x000019F3
    public void ResumeGame()
    {
        this.swordAudio.Play();
        this.pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Token: 0x06000056 RID: 86 RVA: 0x0000381A File Offset: 0x00001A1A
    public void SetVolume(float value)
    {
        this.audioMixer.SetFloat("MainVolume", value);
    }

    // Token: 0x04000069 RID: 105
    public GameObject pauseMenu;

    // Token: 0x0400006A RID: 106
    public AudioSource swordAudio;

    // Token: 0x0400006B RID: 107
    public AudioMixer audioMixer;
}
