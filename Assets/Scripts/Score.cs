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
    public TextMeshProUGUI HighScoreText;
    public float TargetScore = 10f;

    private float CurrentScore = 0f;
    private float FinalScore = 0f;



    void Start()
    {
        float HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
        if (HighScore > 0f)
        {
            HighScoreText.text = "HI " + HighScore.ToString("0") + " m.";

        }

    }

    void Update()
    {

        if (CurrentScore >= TargetScore)
        {
            Global.GroundMovementSpeed += 0.2f;
            TargetScore *= 1.1f;
        }


        if (!Player.dead)
        {


            CurrentScore += Global.GroundMovementSpeed * Time.deltaTime;
            ScoreText.text = CurrentScore.ToString("0") + " m.";

        }
        else
        {
            FinalScore = CurrentScore;
            ScoreText.text = FinalScore.ToString("0") + " m.";

            if (FinalScore >= PlayerPrefs.GetFloat("HighScore", 0f))
            {
                PlayerPrefs.SetFloat("HighScore", FinalScore);
            }

        }
    }

}





//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Global
//{
//    public static float GroundMovementSpeed = 5f;
//}

//public class Score : MonoBehaviour
//{
//    public PlayerController Player;

//    public TextMeshProUGUI ScoreText;
//    public TextMeshProUGUI HighScoreText;

//    public float TargetScore = 10f;
//    public float FinalScore;

//    private float ScoreCount;

//    void Start()
//    {
//        float lastScore = PlayerPrefs.GetFloat("HighScore", 0f);
//        if (lastScore > 0)
//        {
//            HighScoreText.text = "HI " + FinalScore.ToString("0") + " m.";
//        }
//    }

//    private void Update()
//    {

//        if (ScoreCount > PlayerPrefs.GetFloat("HighScore", 0f))
//        {
//            PlayerPrefs.SetFloat("HighScore", ScoreCount);
//        }

//        if (ScoreCount >= TargetScore)
//        {
//            Global.GroundMovementSpeed += 0.2f;
//            TargetScore *= 1.1f;
//        }


//        if (!Player.dead)
//        {
//            ScoreCount += Global.GroundMovementSpeed * Time.deltaTime;
//            ScoreText.text = ScoreCount.ToString("0") + " m.";

//        }
//        else
//        {
//            FinalScore = ScoreCount;
//            ScoreText.text = FinalScore.ToString("0") + " m.";
//        }

//    }




//}


