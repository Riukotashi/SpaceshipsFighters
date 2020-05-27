using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;



public class Game : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject endScreen;
    public TextMeshProUGUI winnerText;
    string winner;
    string loser;
    private int end = 0;

    void Start()
    {
        winnerText.text = null;
    }

    void PrintEndMenu(string winner)
    {
        winnerText.text = winner + "Win";
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(end == 0)
        {
            if (player1.activeSelf == false)
            {
                EndGame(player2.name, player1.name);

            }
            if (player2.activeSelf == false)
            {
                EndGame(player1.name, player2.name);
            }
        }
    }

    void EndGame(string _winner, string _loser)
    {
        winner = _winner;
        loser = _loser;
        DBConnection.InsertScore(_winner, _loser);
        PrintEndMenu(winner);
        end++;
    }

    void SaveScore(string winner, string loser)
    {
    }
}
