
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System.Collections.Generic;
public class MontyHall : UdonSharpBehaviour
{
    public bool round1 = true;
    public bool round2 = false;
    public bool win = false;
    public bool lose = false;
    public int wins = 0;
    public int losses = 0;
    public int gameNumber = 1;
    public int gamesCompletedCount = 0;

    public GameObject round1textGO;
    public GameObject round2textGO;
    public AudioClip round1Clip;
    public AudioClip round2Clip;


    public bool door1goat;
    public bool door2goat;
    public bool door3goat;

    public GameObject door1goatGO;
    public GameObject door2goatGO;
    public GameObject door3goatGO;

    public bool door1car;
    public bool door2car;
    public bool door3car;

    public GameObject door1carGO;
    public GameObject door2carGO;
    public GameObject door3carGO;

    public bool door1open;
    public bool door2open;
    public bool door3open;

    public GameObject door1GO;
    public GameObject door2GO;
    public GameObject door3GO;

    public AudioSource audio;
    public AudioClip winClip;
    public AudioClip loseClip;

    public void InitStuff()
    {
        door1GO = GameObject.Find("door1");
        door2GO = GameObject.Find("door2");
        door3GO = GameObject.Find("door3");
        door1goatGO = GameObject.Find("door1goat");
        door2goatGO = GameObject.Find("door2goat");
        door3goatGO = GameObject.Find("door3goat");
        door1carGO = GameObject.Find("door1car");
        door2carGO = GameObject.Find("door2car");
        door3carGO = GameObject.Find("door3car");
    }

    public void ChooseDoor1()
    {
        if (round2 && !door1open)
        {
            if (door1goat)
            {
                lose = true;
                win = false;
                door1goatGO.SetActive(true);
            }
        }
        if (round1 && !door1open)
        {
            door1goat = true;
            door1goatGO.SetActive(true);
            round1 = false;
            round2 = true;
        }
        door1open = true;
        door1GO.SetActive(false);
    }

    public void ChooseDoor2()
    {
        if (round2 && !door1open)
        {
            if (door1goat)
            {
                lose = true;
                win = false;
                door1goatGO.SetActive(true);
            }
        }
        if (round1 && !door1open)
        {
            door1goat = true;
            door1goatGO.SetActive(true);
            round1 = false;
            round2 = true;
        }
        door2open = true;
        door2GO.SetActive(false);
    }

    public void ChooseDoor3()
    {
        door3open = true;
        door3GO.SetActive(false);
    }

    public void Win()
    {
        win = true;
        lose = false;
        audio.PlayOneShot(winClip);
        wins++;
    }

    public void Lose()
    {
        win = false;
        lose = true;
        audio.PlayOneShot(loseClip);
        losses++;
    }

    void Start()
    {
        InitStuff();
    }
}
