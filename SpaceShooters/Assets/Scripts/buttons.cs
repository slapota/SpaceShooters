using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public GameObject rocket, playAgain;
    public asteroids_M ast;


    bool Button()
    {
        if(Time.timeScale == 0)
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
    }

    public void Click()
    {
        rocket.SetActive(false);
        rocket.SetActive(true);
        Time.timeScale = 1;
        ast.score = 0;
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
        playAgain.SetActive(false);
        rocket.SetActive(true);
        yield return new WaitUntil(Button);
        playAgain.SetActive(true);
        yield return new WaitWhile(Button);
        StartCoroutine(Active());
    }
}
