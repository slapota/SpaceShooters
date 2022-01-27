using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids : MonoBehaviour
{
    public Quaternion rot;

    private void Update()
    {
        transform.position += new Vector3(0, -2, 0) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime);
        if(transform.position.y < -6f)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bolt(Clone)" || other.name == "Player")
        {
            GameObject.Find("Asteroids").GetComponent<asteroids_M>().Boom();
            Destroy(gameObject);
        }
    }
}
