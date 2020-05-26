using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;



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
                SaveScore(winner, loser);
                end++;
            }
            if (player2.activeSelf == false)
            {

                winner = player1.name;
                loser = player2.name;
                Debug.Log("winner is" + winner);
                SaveScore(winner, loser);
                end++;
            }
        }
    }

    void SaveScore(string winner, string loser)
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/SpaceshipsFigthersScore";
        Debug.Log("path de la bdd sqlite " + Application.persistentDataPath);

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS gameHisto (id INTEGER PRIMARY KEY, winner TEXT, loser TEXT)";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        // Insert values in table
        IDbCommand insert = dbcon.CreateCommand();
        insert.CommandText = "INSERT INTO gameHisto (winner,loser) VALUES (@winner, @loser)";
        insert.Parameters.Add(new SqliteParameter("@winner", winner));
        insert.Parameters.Add(new SqliteParameter("@loser", loser));
        insert.ExecuteNonQuery();
        dbcon.Close();


    }
}
