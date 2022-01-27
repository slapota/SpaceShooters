using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController move;
    public float speed;
    public AudioSource boom;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

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
