using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBolt;
    public AudioSource shot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.position += new Vector3(0, -2, 0) * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bolt(Clone)" || other.name == "Player")
        {
            GameObject.Find("Asteroids").GetComponent<asteroids_M>().EnemyBoom();
            Destroy(this.gameObject);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        Instantiate(enemyBolt, transform.position - new Vector3(0, 1f, 0), enemyBolt.transform.rotation);
        shot.Play();
        StartCoroutine(Shoot());
    }
    /*IEnumerator Move()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if(transform.position.x < 0)
        {
            transform.position += 
        }
    }*/
}
