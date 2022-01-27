using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt : MonoBehaviour
{
    public float pSpeed;
    

    private void Update()
    {
        transform.position += Vector3.up * pSpeed * Time.deltaTime;
        if(transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Asteroids").GetComponent<asteroids_M>().score++;
        Destroy(this.gameObject);
    }
}
