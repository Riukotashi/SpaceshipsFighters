using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.IO;

public static class DBConnection
{
    static string pathFile = Application.persistentDataPath + "/SpaceshipsFigthersScore";
    static string dbPath = "URI=file:" + pathFile;

    static public void InsertScore(string winner, string loser)
    {
        if (File.Exists(pathFile) == false)
        {
            CreateSchema();
        }

        IDbConnection dbcon = new SqliteConnection(dbPath);
        dbcon.Open();

        IDbCommand insert = dbcon.CreateCommand();
        insert.CommandText = "INSERT INTO gameHisto (winner,loser) VALUES (@winner, @loser)";
        insert.Parameters.Add(new SqliteParameter("@winner", winner));
        insert.Parameters.Add(new SqliteParameter("@loser", loser));
        insert.ExecuteNonQuery();
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

        IDbCommand select = dbcon.CreateCommand();
        select.CommandText = "SELECT count(id), winner FROM gameHisto GROUP BY winner;";
        IDataReader reader = select.ExecuteReader();

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


    static void CreateSchema()
    {
        IDbConnection dbcon = new SqliteConnection(dbPath);
        dbcon.Open();

        IDbCommand dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS gameHisto (id INTEGER PRIMARY KEY, winner TEXT, loser TEXT)";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();
        dbcon.Close();
    }
}
