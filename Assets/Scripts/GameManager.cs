﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
    //public float timePerProblem;    // time allowed to answer each problem

    //public float remainingTime;     // time remaining for the current problem

    public PlayerController player; // player object
    public SliderController slider;

    // instance
    public static GameManager instance;
    public LevelManager sceneManager;
    public ObstacleSpawner obstacleSpawner;

    public AudioSource CorrectSoundEffect;


    void Awake ()
    {
        // set instance to this script.
        instance = this;
    }

    void Start ()
    {
        // set the initial problem
        SetProblem(0);
        obstacleSpawner = GetComponent<ObstacleSpawner>();
        //CorrectSoundEffect = GetComponent<AudioSource>();
    }

    void Update ()
    {
        //remainingTime -= Time.deltaTime;

        // has the remaining time ran out?
        //if(remainingTime <= 0.0f)
        //{
        //    Lose();
        //}
    }

    // called when the player enters a tube
    public void OnPlayerEnterTube (int tube)
    {
        // did they enter the correct tube?
        if (tube == problems[curProblem].correctTube)
        {
            CorrectAnswer();
            slider.UpdateProgress();
        }
        else
            IncorrectAnswer();
    }

    // called when the player enters the correct tube
    void CorrectAnswer()
    {
        CorrectSoundEffect.Play();
        
        // is this the last problem?
        if (problems.Length - 1 == curProblem)
        {
            Win();
        }
        else
            SetProblem(curProblem + 1);
    }

    // called when the player enters the incorrect tube
    void IncorrectAnswer ()
    {
        player.Stun();
    }

    // sets the current problem
    void SetProblem (int problem)
    {
        obstacleSpawner.spawnRate = obstacleSpawner.spawnRate - 0.1f;
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
        //remainingTime = timePerProblem;
    }

    // called when the player answers all the problems
    public void Win ()
    {
        sceneManager.WinGame();
        //UI.instance.SetEndText(true);
    }

    // called if the remaining time on a problem reaches 0
    public void Lose ()
    {
        Time.timeScale = 0;
        //Rigidbody rb = player.GetComponet
        UI.instance.SetEndText();
    }
}