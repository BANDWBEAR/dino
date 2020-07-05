using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Global
{

    public static float GroundMovementSpeed = 5f;

}


public class Score : MonoBehaviour
{
    public PlayerController Player;

    public TextMeshProUGUI ScoreText;
    public float TargetScore = 10f;
    public float FinalScore;

    private float ScoreCount;


    // Update is called once per frame
    void Update()
    {
        if (ScoreCount >= TargetScore)
        {
            Global.GroundMovementSpeed += 0.1f;
            Debug.Log("Gorund Speed" + Global.GroundMovementSpeed);
            TargetScore *= 1.1f;
        }

        if (!Player.dead)
        {
            ScoreCount += Global.GroundMovementSpeed * Time.deltaTime;
            ScoreText.text = ScoreCount.ToString("0") + " m.";

        }
        else
        {
            FinalScore = ScoreCount;
            ScoreText.text = FinalScore.ToString("0") + " m.";

        }

    }
}


