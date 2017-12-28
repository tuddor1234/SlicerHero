﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public bool isCutting=false;

    Rigidbody2D rb;
    Camera cam;
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
	}
	
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
	}

    void StartCutting()
    {
        isCutting = true;

    }

    void StopCutting()
    {
        isCutting = false;

    }

    void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

}
