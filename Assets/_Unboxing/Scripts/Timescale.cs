using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timescale : MonoBehaviour {
    public float timespeed = 1f;
	// Use this for initialization
	void Start () {
        Time.timeScale = timespeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
