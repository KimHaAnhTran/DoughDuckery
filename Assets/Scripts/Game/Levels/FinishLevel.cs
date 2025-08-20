using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    FadeInOut fade;
    [SerializeField] private float endSpeed = 1f;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator _ChangeScene()
    {
        yield return new WaitForSeconds(endSpeed);
        levelCompleted = true;
        CompleteLevel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !levelCompleted)
        {
            fade.FadeIn();
            StartCoroutine(_ChangeScene());
        }
    }

    private void CompleteLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
