﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inputmanager : MonoBehaviour {

	public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }
}
