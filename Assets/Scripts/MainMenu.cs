using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : Menu
{
    public void Score()
    {
        Transform scoreMenu;
        scoreMenu = transform.Find("ScoresMenu");

        Transform scoreContanier;
        scoreContanier = scoreMenu.Find("ScoreContainer");

        Transform scoreTemplate;
        scoreTemplate = scoreContanier.Find("ScoreTemplate");

        scoreTemplate.gameObject.SetActive(false);

        float templateHeight = 64f;
        List<PlayerScore> playerScores = DBConnection.GetScore();
        for (int i = 0; i < playerScores.Count; i++)
        {

            Transform scoreTransform = Instantiate(scoreTemplate, scoreContanier);
            RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>();
            scoreRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            scoreTransform.gameObject.SetActive(true);
            scoreTransform.Find("VictoryNumber").GetComponent<TextMeshProUGUI>().text = playerScores[i].nbVictory.ToString();
            scoreTransform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = playerScores[i].name;
        }
    }
}
