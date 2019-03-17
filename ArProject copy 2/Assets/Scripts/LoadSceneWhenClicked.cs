﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWhenClicked : MonoBehaviour {

    public void LoadByIndex (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneFromStart(int sceneIdx)
    {
       // Application.loadedLevel(Application.loadedLevel);
    }
}
