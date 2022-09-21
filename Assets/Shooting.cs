using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject shootFlash;
    public float bulletForce;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            StartCoroutine(Example());
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator Example()
    {
        shootFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        shootFlash.SetActive(false);
    }
}