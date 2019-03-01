﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour {

    public Text recordText;
    public fade fade;

    private void Start()
    {
        recordText.text = "record: " + PlayerPrefs.GetInt("record").ToString();
    }

    public void Press(){
        fade.FadeToLevel(1);
    }
}
