﻿using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    private float minX, maxX;

	// Use this for initialization
	void Start () {
        Vector3 coor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));// to get scrren size x and y.
        minX = -coor.x + 0.5f;
        maxX = coor.x-0.5f;
	}
	
	// Update is called once moving basket over the screen bounds
	void Update () {
        Vector3 temp = transform.position;
        if (temp.x > maxX) temp.x = maxX;
        if (temp.x < minX) temp.x = minX;
        transform.position = temp;
	}
}
