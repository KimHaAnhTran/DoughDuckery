using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public float time = 1f;
    public void StartGame() {

        StartCoroutine("LoadCutscene1", time);
    }

    public void replayGame()
    {
        StartCoroutine("LoadLvl1", time);
    }

    public void playCutscene3()
    {
        StartCoroutine("LoadCutsceneLvl3", time);
    }

    IEnumerator LoadCutscene1(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Lvl1_Cutscene");
    }
    IEnumerator LoadLvl1(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level1");
    }



    public void retryGame()
    {
        StartCoroutine("LoadLvl3", time);
    }

    IEnumerator LoadLvl3(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level3");
    }

    IEnumerator LoadCutsceneLvl3(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Lvl3_Cutscene");
    }

    public void lvl2()
    {
        StartCoroutine("LoadLvl2", time);
    }

    IEnumerator LoadLvl2(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level2");
    }

    public void returnMenu()
    {
        StartCoroutine("Menu", time);
    }

    IEnumerator Menu(float time)
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("0_Start Screen");
    }

    public void nextScene()
    {
        StartCoroutine("loadNextScene", time);
    }

    IEnumerator loadNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
