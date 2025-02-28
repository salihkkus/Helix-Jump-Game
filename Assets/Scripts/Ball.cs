using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpForce;
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * JumpForce);

        string MaterialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log(MaterialName);

        if(MaterialName == "SafeColor (Instance)")
        {
            //get points
        }
        else if(MaterialName == "UnsafeColor (Instance)")
        {
            //restart game
            Debug.Log("game over");
        }
        else if(MaterialName == "Last Ring (Instance)")
        {
            //skip next level
        }
    }
}
