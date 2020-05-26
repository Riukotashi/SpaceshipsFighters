using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    string winner;
    string loser;
    private int end = 0;

    void Update()
    {
        if(end == 0)
        {
            if (player1.activeSelf == false)
            {
                winner = player2.name;
                loser = player1.name;
                Debug.Log("winner is" + winner);
                end++;
            }
            if (player2.activeSelf == false)
            {

                winner = player1.name;
                loser = player2.name;
                Debug.Log("winner is" + winner);
                end++;
            }
        }
    }

    void SaveScore()
    {
        

    }
}
