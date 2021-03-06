﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int actuallColor = -1;

	void Start () {
        ChangeColor();
    }
	
	void Update () {
		
	}

    public void ChangeColor(){
        actuallColor = FindObjectOfType<ColorsHandler>().GetRandomColor(actuallColor);
        SetColor();

    }

    void SetColor(){
        GetComponent<SpriteRenderer>().color = FindObjectOfType<ColorsHandler>().colors[actuallColor];
        if (FindObjectOfType<BallColors>().actuallColor == actuallColor)
            GetComponent<BoxCollider2D>().isTrigger = true;
        else GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "shoot" && FindObjectOfType<BallColors>().actuallColor != actuallColor){
            if(FindObjectOfType<BallColors>().actuallColor != 3)
                ChangeColor();
            else {
                actuallColor = 3;
                SetColor();
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ball" && FindObjectOfType<BallColors>().actuallColor != actuallColor)
       {
            if (collision.gameObject.GetComponent<BallColors>().actuallColor != actuallColor)
                collision.gameObject.GetComponent<Ball>().GetDamage(1);
        }

    }
}
