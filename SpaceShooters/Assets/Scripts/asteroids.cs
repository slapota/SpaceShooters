using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Quaternion rot;
    public ParticleSystem explosion;

    private void Update()
    {
        transform.position += new Vector3(0, -2, 0) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime);
        if(transform.position.y < -6f)
        {
            Instantiate(explosion, transform.position, transform.rotation).Play();
            Time.timeScale = 0.05f;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bolt(Clone)" || other.name == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject.Find("Asteroids").GetComponent<AsteroidsM>().boom.Play();
            Destroy(gameObject);
        }
    }
}
