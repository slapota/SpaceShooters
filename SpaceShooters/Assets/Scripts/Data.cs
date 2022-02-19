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
    public Color rgb;
    public float boltVolume;
    public bool slim;

    public Data(string name, string key, int high, float sounds, Color color, float shots, bool toggle)
    {
        score = high;
        userName = name;
        password = key;
        volume = sounds;
        rgb = color;
        boltVolume = shots;
        slim = toggle;
    }
}
