/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

//This will be our State Manager

public class MissionDemolition : MonoBehaviour
{
    public static MissionDemolition Instance;

    public GameObject[] castles;

    public Text textLevel, textShots;
    public Vector3 castlePos;

    public int level, levelMax, shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot";

    private void Start()
    {
        Instance = this;
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    private void StartLevel()
    {
        //get rid of any castles that already exist in scene
        if (castle != null)
        {
            Destroy(castle);
        }

        //Instantiate a castle
        castle = Instantiate(castles[level]);

        // move it to the correct location
        castle.transform.position = castlePos;

        //init the shot tracker
        shotsTaken = 0;

        //reset the camera
        SwitchView("Both");
        projectileLine.Instance.Clear();

        //reset the goal
        goal.goalMet = false;

        mode = GameMode.playing;

    }

    private void ShowText()
    {
        textLevel.text = "Level:" + (level + 1) + "of" + levelMax;
        textShots.text = "Shots Taken:" + shotsTaken;
    }

    private void Update()
    {
        //this is okay for prototyping but not for production
        ShowText();

        //check for level end
        if (mode == GameMode.playing && goal.goalMet)
        {
            //change the mode to stop checking for level
            mode = GameMode.levelEnd;

            //zoom out
            SwitchView("Both");

            //start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }

    private void NextLevel()
    {
        level++;

        //if we get ot the end, just loop back to the beginning
        if (level == levelMax)
        {
            level = 0;
        }

        //start the next level
        StartLevel();
    }

    static public void SwitchView(string eView)
    {
        Instance.showing = eView;
        switch (Instance.showing)
        {
            case "Slingshot":
                FollowCam.Instance.poi = null;
                break;
            case "Castle":
                FollowCam.Instance.poi = Instance.castle;
                break;
            case "Both":
                FollowCam.Instance.poi = GameObject.Find("ViewBoth");
                break;
            default:
                break;
        }
    }


}
*/