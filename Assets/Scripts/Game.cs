using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;



public class Game : MonoBehaviour
{
    public GameObject endScreen;
    public TextMeshProUGUI winnerText;
    private GameObject player1;
    private GameObject player2;
    private string winner;
    private string loser;
    private int end = 0;

    private void Awake()
    {
        winnerText.text = null;
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    private void PrintEndMenu(string winner)
    {
        winnerText.text = winner + "Win";
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
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

    private void EndGame(string _winner, string _loser)
    {
        winner = _winner;
        loser = _loser;
        DBConnection.InsertScore(_winner, _loser);
        PrintEndMenu(winner);
        end++;
    }
}
