using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text leftScore;
    public Text rightScore;

    private int scoreLeft, scoreRight;
    public static ScoreScript S;
    public void Awake()
    {
        scoreLeft = 0;
        scoreRight = 0;
        S = this;
    }
    // Start is called before the first frame update


    public void UpdateScore(int scorer)
    {
        if(scorer == 0)
        {
            scoreLeft++;
            leftScore.text = scoreLeft.ToString();
        }

        if(scorer == 1)
        {
            scoreRight++;
            rightScore.text = scoreRight.ToString();
        }
    }
}
