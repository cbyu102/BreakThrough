﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BREAKTHROUGH : MonoBehaviour
{
    //Custom Properties file for Networking.
    static public bool PLAYER_ONLINE = false;
    public const string PLAYER_READY = "isPlayerReady";
    public const string PLAYER_LOADED_LEVEL = "PlayerLoadedLevel"; // TODO: SET THE TRUE PROPERTY SOMEWHERE, possibly under TS2, ROUNDSTART
}