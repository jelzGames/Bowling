using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    public Text standingDisplay;

    private bool ballOutPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    private GameManager gameManager;
   

    // Use this for initialization
    void Start () {
        gameManager = GameManager.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        standingDisplay.text = CountStanding().ToString();

        if (ballOutPlay)
        {
            UpdateStandingCount();
            standingDisplay.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    public int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }

    void UpdateStandingCount()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
        }

        float settleTime = 3f; // how long to wait to cnsider pins settled, when there are spinning

        if (Time.time - lastChangeTime > settleTime) // if last change > 3s ago
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; // indicates pins have settled, and ball not back in box
        ballOutPlay = false;
        standingDisplay.color = Color.green;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutPlay = true;
        }
    }

}
