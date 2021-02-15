using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;

    private int leftScore = 0;
    private int rightScore = 0;
    public Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        //For Left Text
        if(leftScore >= 100){
            leftTextScore.text = "" + leftScore;
        }

        else if(leftScore >= 10){
           leftTextScore.text = "0" + leftScore;
        }

        else {
            leftTextScore.text = "00" + leftScore;
        }

        if(leftScore >= 5)
        {
            leftTextScore.color = textColor;
        }

        //For Right Text
        if(rightScore >= 100){
            rightTextScore.text = "" + rightScore;
        }

        else if(rightScore >= 10){
           rightTextScore.text = "0" + rightScore;
        }

        else {
            rightTextScore.text = "00" + rightScore;
        }

        if(rightScore >= 5)
        {
            rightTextScore.color = textColor;
        }
    }
    public void AddScore(Goal scoringSide)
    {
        if (scoringSide == leftGoal)
        {
            rightScore += 1;
        }

        else
        {
            leftScore += 1;
        }
        RefreshScore();
    }
}
