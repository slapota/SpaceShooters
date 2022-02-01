using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float pSpeed;
    public Score score;

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
        GameObject.Find("Canvas").GetComponent<Score>().score++;
        Destroy(this.gameObject);
    }
}
