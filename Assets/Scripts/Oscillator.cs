﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f; //time it takes to complete 1 full cycle

    // todo remove from inspector later

    float movementFactor;
    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2f; // ~6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
