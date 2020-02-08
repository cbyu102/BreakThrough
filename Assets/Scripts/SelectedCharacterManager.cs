﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharacterManager : MonoBehaviour
{
    public string stage;
    public string P1Character;
    public string P2Character;
    public int P1Color;
    public int P2Color;

    private static bool created = false;
    private bool reset = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }      
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CharacterSelect" && reset == false)
        {
            stage = "";
            P1Character = "";
            P2Character = "";
            P1Color = 0;
            P2Color = 0;
            reset = true;
        }
        else if (SceneManager.GetActiveScene().name != "CharacterSelect")
        {
            reset = false;
        }
    }
}
