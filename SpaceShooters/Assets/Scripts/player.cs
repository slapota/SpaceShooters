using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController move;
    public float speed;
    public AudioSource boom;
    float x;
    float y;

    private void Update()
    {
        x = 0;
        y = 0;

        if (transform.position.x > -3.2f && Input.GetKey(KeyCode.A) && x >= -1f)
        {
            x = Input.GetAxis("Horizontal");
        }

        if (transform.position.x < 3.2f && Input.GetKey(KeyCode.D) && x <= (1f))
        {
            x = Input.GetAxis("Horizontal");
        }

        if (transform.position.y > -4.8f && Input.GetKey(KeyCode.S) && y >= (-1f))
        {
            y = Input.GetAxis("Vertical");
        }

        if (transform.position.y < 4.8f && Input.GetKey(KeyCode.W) && y <= (1f))
        {
            y = Input.GetAxis("Vertical");
        }

        move.Move(y * Vector2.up * Time.deltaTime * speed);
        move.Move(x * Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bolt(Clone)")
        {
            boom.Play();
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
