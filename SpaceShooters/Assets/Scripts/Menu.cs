using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject settings;
    bool active = false;
    public Slider music, bolts;
    public Text text, shot;
    public float volume, boltVolume;
    public Buttons buttons;
    public AsteroidsM ast;


    void Start()
    {
        settings.SetActive(false);
        volume = 0.5f;
        boltVolume = 0.5f;
        text.text = "MUSIC: 0.5";
        shot.text = "GAME: 0.5";
        music.onValueChanged.AddListener((v) =>
        {
            volume = v;
            buttons.GetComponent<Buttons>().music.volume = v;
            text.text = $"MUSIC: {volume}";
        });
        bolts.onValueChanged.AddListener((v) =>
        {
            AsteroidsM am = ast.GetComponent<AsteroidsM>();
            am.playerBoom.volume = v;
            am.boom.volume = v;
            am.enemyBoom.volume = v;
            boltVolume = v;
            shot.text = $"GAME: {boltVolume}";
        });
    }
    public void LoadVolume(float v, float b)
    {
        music.value = v;
        bolts.value = b;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !active)
        {
            active = true;
            settings.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = false;
            Time.timeScale = 1;
            settings.SetActive(false);
        }
    }
}
