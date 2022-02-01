using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject rocket, playAgain;
    public AudioSource music;
    public Text highScore;
    public int high;


    bool Button()
    {
        if(Time.timeScale == 0.05f)
        {
            return (true);
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        StartCoroutine(Active());
        music.Play();
    }

    public void Click()
    {
        rocket.SetActive(false);
        rocket.transform.position = new Vector3(0, -4, 0);
        rocket.SetActive(true);
        Time.timeScale = 1;
        GameObject.Find("Canvas").GetComponent<Score>().score = 0;
        GameObject[] asteroids = FindObjectsOfType<GameObject>();
        foreach (var item in asteroids)
        {
            if(item.name.Contains("Clone"))
            {
                Destroy(item);
            }
        }
    }

    IEnumerator Active()
    {
        highScore.text = "";
        playAgain.SetActive(false);
        rocket.SetActive(true);
        yield return new WaitUntil(Button);
        playAgain.SetActive(true);
        if(GameObject.Find("Canvas").GetComponent<Score>().score > high)
        {
            high = GameObject.Find("Canvas").GetComponent<Score>().score;
        }
        highScore.text = $"HighScore: {high}";
        yield return new WaitWhile(Button);
        StartCoroutine(Active());
    }
}
