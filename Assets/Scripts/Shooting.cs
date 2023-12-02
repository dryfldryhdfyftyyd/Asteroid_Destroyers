using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public Transform firePoint;
    private AudioSource audioSource;
    private float cooldownTimer = 0f; 

    public Text cooldownText;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    void Update()
    {
        
        cooldownTimer -= Time.deltaTime;

        
        UpdateCooldownText();

        
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0f)
        {

            Shoot();
            audioSource = GetComponent<AudioSource>();
            cooldownTimer = fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
    void UpdateCooldownText()
    {
        
        if (cooldownText != null)
        {
            cooldownText.text = "Cooldown: " + Mathf.Ceil(cooldownTimer).ToString();
        }
    }
}
