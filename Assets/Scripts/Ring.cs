using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
   public Transform Ball;
   private GameManager gm;
    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();
    }

   
    void Update()
    {
        if(transform.position.y + 12f >= Ball.position.y)
        {
        Destroy(gameObject);
        gm.gameScore(25);
        }
    }
}
