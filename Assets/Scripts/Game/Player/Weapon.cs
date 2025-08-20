using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public int bullets = 0;
    public GameObject bulletPrefab;
    [SerializeField] private AudioSource shootSFX;
    public TextMeshProUGUI bulletsText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bullets > 0)
        {
            Shoot();
            bullets--;
            updateBullets();
        }
    }
    void Shoot()
    {
        shootSFX.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("recharge"))
        {
            bullets = 10;
            updateBullets();
        }
    }

    void updateBullets()
    {
        bulletsText.text = bullets.ToString();
    }
}
