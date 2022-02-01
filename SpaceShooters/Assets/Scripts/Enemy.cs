using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBolt;
    public AudioSource shot;
    float dodgeSpeed;
    public ParticleSystem explosion;

    private void Start()
    {
        StartCoroutine(Shoot());
        StartCoroutine(Move());
    }

    private void Update()
    {
        transform.position += new Vector3(dodgeSpeed, -2, 0) * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Time.timeScale = 0.05f;
            Instantiate(explosion, transform.position, transform.rotation).Play();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bolt(Clone)" || other.name == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject.Find("Asteroids").GetComponent<AsteroidsM>().enemyBoom.Play();
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        Instantiate(enemyBolt, transform.position - new Vector3(0, 1f, 0), enemyBolt.transform.rotation);
        shot.Play();
        StartCoroutine(Shoot());
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (transform.position.x > 0)
        {
            dodgeSpeed = Random.Range(-1f, -2f);
        }
        else
        {
            dodgeSpeed = Random.Range(1f, 2f);
        }
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        dodgeSpeed = 0;
    }
}
