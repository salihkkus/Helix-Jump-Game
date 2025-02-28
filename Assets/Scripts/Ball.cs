using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    private GameManager gm;
    public GameObject splashPrefab;
    public float JumpForce = 10f; // Default değer

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        // Splash efektini oluştur ve parent olarak çarptığı objeyi belirle
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f, -0.24f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        // Topun yukarı yönlü hızını sıfırlayıp, yeni velocity belirleme
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);

        // Çarpılan yüzeyin materyal adını kontrol et
        string MaterialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log(MaterialName);

        if (MaterialName == "UnsafeColor (Instance)")
        {
            gm.RestartGame();
        }
        else if (MaterialName == "Last Ring (Instance)")
        {
            Debug.Log("Next Level");
        }
    }
}
