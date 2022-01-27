using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    public float eSpeed;

    private void Update()
    {
        transform.position += Vector3.down * eSpeed * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
