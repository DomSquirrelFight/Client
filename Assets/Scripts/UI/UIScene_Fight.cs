﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_Fight : UIScene {
    public GameObject button;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(button).onClick = GoBegin;
	}
	void GoBegin(GameObject obj)
    {
        GlobalHelper.LoadLevel("Begin");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
