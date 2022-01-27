using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroids_M : MonoBehaviour
{
    public GameObject[] asteroids = new GameObject[3];
    public GameObject enemy;
    public Text text;
    public bolt ast;
    public int score = 0;
    public AudioSource boom, enemyBoom;

    private void Start()
    {
        StartCoroutine(Spawning());
    }
    void Update()
    {
        text.text = $"Score: {score}";
    }

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        int random = Random.Range(0, 4);
        if (random == 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(-3, 3), 7, 0), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-3, 3), 7, 0), Random.rotation).GetComponent<asteroids>().rot = Random.rotation;
        }
        StartCoroutine(Spawning());
    }

    public void Boom()
    {
        boom.Play();
    }
    public void EnemyBoom()
    {
        enemyBoom.Play();
    }
}
