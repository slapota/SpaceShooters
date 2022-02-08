using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject settings;
    bool active = false;
    public Slider slider;
    public Text text;
    public float volume;
    public Buttons buttons;

    void Start()
    {
        settings.SetActive(false);
        volume = 0.5f;
        text.text = "0.5";
        slider.onValueChanged.AddListener((v) =>
        {
            volume = v;
            buttons.GetComponent<Buttons>().music.volume = v;
            text.text = $"VOLUME: {volume}";
        });
    }
    public void LoadVolume(float v)
    {
        slider.value = v;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !active)
        {
            active = true;
            settings.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            active = false;
            Time.timeScale = 1;
            settings.SetActive(false);
        }
    }
}
