using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField]  public string[] lines;
    [SerializeField] public float speedText;
    public Image squirrel;
    public Image duck;
    public GameObject endFade;

    private int i;
    private bool hasStart = false;
    public bool sign = false;
    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
        
    // Start is called before the first frame update

    public void callDialogue()
    {
        text.text = string.Empty;
        gameObject.SetActive(true);
        
        if (!hasStart)
        {
            hasStart = true;
            startDialogue();
        }
        
    }

    private void Update()
    {
           if (Input.GetMouseButtonDown(0))
            {
                if (text.text == lines[i])
                {
                    nextLine();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = lines[i];
                }
            }
        if (!sign)
        {
            if (i % 2 == 0)
            {
                squirrel.enabled = true;
                duck.enabled = false;
            }
            else
            {
                squirrel.enabled = false;
                duck.enabled = true;
            }
        }
        else
        {
            duck.enabled = false;
            squirrel.enabled = false;
        }
    }

    void startDialogue()
    {
        i = 0;
        StartCoroutine(typeLine());
    }

    IEnumerator typeLine()
    {
        foreach (char c in lines[i].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }
    void nextLine()
    {
        if (i < lines.Length - 1)
        {
            i++;
            text.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if (currentScene.name != "Level1")
            {
                endFade.SetActive(true);
            }
        }
    }
}
