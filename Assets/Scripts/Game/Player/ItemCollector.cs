using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int breads = 0;
    public TextMeshProUGUI breadText;
    [SerializeField] private AudioSource collectSFX;
    [SerializeField] public float goal = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bread"))
        {
            collectSFX.Play();
            breads++;
            Destroy(collision.gameObject);
            breadText.text = "Breads: " + breads + "/" + goal;
        }
    }
}
