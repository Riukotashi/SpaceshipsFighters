using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.IO;

public static class DBConnection
{
    private static string pathFile = Application.persistentDataPath + "/SpaceshipsFigthersScore";
    private static string dbPath = "URI=file:" + pathFile;

    static private void CreateSchema()
    {
        IDbConnection dbcon = new SqliteConnection(dbPath);
        dbcon.Open();

        IDbCommand dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS gameHisto (id INTEGER PRIMARY KEY, winner TEXT, loser TEXT)";
        dbcmd.ExecuteReader();
        dbcon.Close();
    }

    static public void InsertScore(string winner, string loser)
    {
        if (File.Exists(pathFile) == false)
        {
            CreateSchema();
        }

        IDbConnection dbcon = new SqliteConnection(dbPath);
        dbcon.Open();

        IDbCommand dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = "INSERT INTO gameHisto (winner,loser) VALUES (@winner, @loser)";
        dbcmd.Parameters.Add(new SqliteParameter("@winner", winner));
        dbcmd.Parameters.Add(new SqliteParameter("@loser", loser));
        dbcmd.ExecuteNonQuery();
        dbcon.Close();


    }

    static public List<PlayerScore> GetScore()
    {
        if (File.Exists(pathFile) == false)
        {
            CreateSchema();
        }

        IDbConnection dbcon = new SqliteConnection(dbPath);
        dbcon.Open();

        IDbCommand dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = "SELECT count(id) as nb, winner FROM gameHisto GROUP BY winner ORDER BY nb DESC LIMIT 5;";
        IDataReader reader = dbcmd.ExecuteReader();

        List<PlayerScore> playerScores = new List<PlayerScore>();
        while (reader.Read())
        {
            PlayerScore playerScore = new PlayerScore();
            playerScore.name = reader.GetString(1);
            playerScore.nbVictory = reader.GetInt32(0);
            playerScores.Add(playerScore);
        }
       
        reader.Close();
        dbcon.Close();
        return playerScores;
    }
}
