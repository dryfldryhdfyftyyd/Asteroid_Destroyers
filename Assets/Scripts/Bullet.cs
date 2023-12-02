using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Bullet : MonoBehaviour
{
    public GameObject explosionVfx;

    public float speed = 20;
    public float lifetime = 3;

    public Text counterText;
    private int collisionCount = 0;


    private void Start()
    {
        Invoke(nameof(explosionVfx), lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (collisionCount >= 20)
        {
            
            ChangeScene();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject);

            collisionCount++;

            
            if (counterText != null)
            {
                counterText.text =collisionCount.ToString();
            }
        }
    }

    void Explode()
    {
        Instantiate(explosionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void ChangeScene()
    {
        // Change the scene to the one you want
        SceneManager.LoadScene("End");
    }
}
