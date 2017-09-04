using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    List<int> rolls = new List<int>();

    private ScoreDisplay scoreDisplay;

    private PinSetter pinSetter;
    private Ball ball;

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
        ball = GameObject.FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl(int pinFall)
    {
        rolls.Add(pinFall);
        ball.Reset();
        pinSetter.perfomanceAction(ActionMaster.NextAction(rolls));
        
        scoreDisplay.FillRollCard(rolls);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));


    }
}
