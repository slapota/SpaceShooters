using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Data
{
    public string userName;
    public string password;
    public float volume;
    public int score;

    public Data(string name, string key, int high, float sounds)
    {
        score = high;
        userName = name;
        password = key;
        volume = sounds;
    }
}
