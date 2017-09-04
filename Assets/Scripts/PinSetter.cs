using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    
    public GameObject pinSet;
    public float distanceToRise = 40f;

    public enum Action { Reset, Tidy };

    private Animator animator;

  
    private PinCounter pinCounter;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	
	// Update is called once per frame
	void Update () {


    }
    
    public void RisePins()
    {

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding(distanceToRise);
            
        }

    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower(distanceToRise);
        }
    }

    public void RenewPins()
    {

        Instantiate(pinSet, new Vector3(0, 0, 1829), Quaternion.identity);
       
    }


    public Action Roll (int pins)
    {
        return Action.Reset;
    }

    public List<int> GetFrames()
    {
        List<int> list = new List<int>();
        return list;
    }

    public void perfomanceAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("TidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Dont know how to handle end game yet");
        }
    }

}
