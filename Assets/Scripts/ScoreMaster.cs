﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster
{
    

    // returns a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativesScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativesScores.Add(runningTotal);

        }

        return cumulativesScores;
    }

    // return a list of individual frame scores, not culutative
	public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frames = new List<int>();


        // Index i points to 2nd bowl of frame
        for (int i = 1; i <rolls.Count; i += 2)
        {
            if (frames.Count == 10)
            {
                break; //prevent 11thscore  frame
            }

            if (rolls[i - 1] + rolls[i] < 10) // normal "open" frame
            {

                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1) // Ensure at least 1 look-ahead available
            {
                break;
            }

            if (rolls[i - 1] == 10) //Strike
            {
                i--; // strike frame has just one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10) // caluclate spare bonus
            {

                frames.Add(10 + rolls[i+1]);
            }

        }

        return frames;
    }
}
