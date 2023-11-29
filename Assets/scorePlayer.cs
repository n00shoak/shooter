using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorePlayer : MonoBehaviour
{
    public float playerScore = 0;
    public TextMeshProUGUI points;

    public void addScore(int plus)
    {
        playerScore += plus;
        points.text = playerScore.ToString();
    }
}
