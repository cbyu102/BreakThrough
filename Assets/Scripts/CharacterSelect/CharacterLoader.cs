﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject P1Character;
    public GameObject P2Character;
    //public GameObject HitMarker;
    private string P1Char;
    private string P2Char;

    void Awake()
    {
        switch (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Character)
        {
            case "Dhalia":
                P1Char = "CharacterPrefabs/Dhalia";
                break;
            case "Achealis":
                P1Char = "CharacterPrefabs/Achealis";
                break;

        }

        switch (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Character)
        {
            case "Dhalia":
                P2Char = "CharacterPrefabs/Dhalia";
                break;
            case "Achealis":
                P2Char = "CharacterPrefabs/Achealis";
                break;
        }

        setP1Properties();
        setP2Properties();
    }

    void setP1Properties()
    {
        //Load Character and set name
        P1Character = Instantiate(Resources.Load(P1Char, typeof(GameObject)), GameObject.Find("Player1").transform) as GameObject;
        P1Character.name = GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Character;

        //Assign CharacterHandlers
        P1Character.GetComponent<MovementHandler>().MaxInput = GameObject.Find("MaxInput").GetComponent<MaxInput>();

        //Set Character-Specific Scripts
        switch (P1Character.name)
        {
            case "Dhalia":
                setDhaliaProperties(P1Character, GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Color);
                break;
            case "Achealis":
                setAchealisProperties(P1Character, GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Color);
                break;
        }

        //Set Character Position
        if (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Side == "Left")
        {
            GameObject.Find("Player1").transform.position = new Vector3(-1f, 1.127f, -3);
        }
        else
        {
            GameObject.Find("Player1").transform.position = new Vector3(1f, 1.127f, -3);
        }

    }

    void setP2Properties()
    {
        //Load Character and set name
        P2Character = Instantiate(Resources.Load(P2Char, typeof(GameObject)), GameObject.Find("Player2").transform) as GameObject;
        P2Character.name = GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Character;

        //Assign CharacterHandlers
        P2Character.GetComponent<MovementHandler>().MaxInput = GameObject.Find("MaxInput").GetComponent<MaxInput>();

        //Set Character-Specific Scripts
        switch (P2Character.name)
        {
            case "Dhalia":
                setDhaliaProperties(P2Character, GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Color);
                break;
            case "Achealis":
                setAchealisProperties(P2Character, GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Color);
                break;
        }

        //Set Character Position
        if (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Side == "Right")
        {
            GameObject.Find("Player2").transform.position = new Vector3(1f, 1.127f, -3);
        }
        else
        {
            GameObject.Find("Player2").transform.position = new Vector3(-1f, 1.127f, -3);
        }
    }

    //Script-Specific Functions
    void setDhaliaProperties(GameObject Character, int Color)
    {
        //Set MaxInput
        Character.GetComponent<AttackHandlerDHA>().MaxInput = GameObject.Find("MaxInput").GetComponent<MaxInput>();

        //Set Dhalia Color
        Character.transform.GetChild(0).GetComponent<ColorSwapDHA>().colorNum = Color;
    }

    void setAchealisProperties(GameObject Character, int Color)
    {
        //Set MaxInput
        Character.GetComponent<AttackHandlerACH>().MaxInput = GameObject.Find("MaxInput").GetComponent<MaxInput>();

        //Set Achealis Color
        Character.transform.GetChild(0).GetComponent<ColorSwapACH>().colorNum = Color;
    }
}
