using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    private GameManager gm;
    public GameObject splashPrefab;
    public float JumpForce;
    void Update()
    {
        gm = GameManager.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject splash = Instantiate(splashPrefab , transform.position + new Vector3(0f , -0.24f , 0f) , transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        rb.AddForce(Vector3.up * JumpForce);

        string MaterialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log(MaterialName);

        if(MaterialName == "UnsafeColor (Instance)")
        {
            gm.RestartGame();
        }
        else if(MaterialName == "Last Ring (Instance)")
        {
            Debug.Log("Next Level");
        }
    }
}
