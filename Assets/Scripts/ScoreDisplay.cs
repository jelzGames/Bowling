using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollsTexts, frameTexts;

	// Use this for initialization
	void Start () {
 

    }

    
    // Update is called once per frame
    void Update () {
		
	}



    public void FillRollCard(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);

        for (int i = 0; i < scoreString.Length; i++)
        {
            rollsTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i=0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls (List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;                            // score bx 1 to 21

            if (rolls[i] == 0)                                      // always enter 0 as -
            {
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && (rolls[i-1] + rolls[i] == 10)) //spare anywhere
            {
                output += "/";                                     
            }
            else if (box >= 19 && rolls[i] == 10)                   //strike 10
            {
                output += "X";
            }
            else if (rolls[i] == 10)                                //strike 1-9
            {
                output += "X "; 
            }
            else
            {
                output += rolls[i].ToString();                      // normal 1-9 bowl
            }
        }

        return output;
    }
}
