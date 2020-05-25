using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    string winner;
    string loser;
    void Start()
    {
        
    }

    void Update()
    {

        if (player1.activeSelf == true)
        {
            Debug.Log("Player1 Win");
        }
        if (player1.activeSelf == true)
        {
            Debug.Log("Player2 Win");
        }
    }

    void Finish()
    {
    }
}
