using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoSingleton<GameManager>
{

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    
    public void LevelFail()
    {
    }

    public void LevelWin()
    {
    }
    
    
}