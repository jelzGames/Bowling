using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOld {

    public enum Action {Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMasterOld actionMAster = new ActionMasterOld();
        Action currentAction = new Action();

        foreach(int pinfall in pinFalls)
        {
            currentAction = actionMAster.Bowl(pinfall);
        }

        return currentAction;
    }

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.EndGame;
        }
       
        // handle last-frames special cases
        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl++;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
            {
                return Action.Tidy;
            }
            else if ((bowls[19 - 1] + bowls[20 - 1]) == 10)
            {
                return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            return Action.EndGame;
        }
        

        if ((bowl % 2) != 0)  // First bowl of frame 
        {
            if (pins == 10)
            {
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl++;
                return Action.Tidy;
            }
        }
        else if  (bowl % 2 == 0) //Second bowl of frames 1-9
        {
            bowl++;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");
    }

	private bool Bowl21Awarded()
    {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }

   
}
