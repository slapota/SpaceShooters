using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController move;
    public float speed;
    float x;
    float y;
    public ParticleSystem explosion;
    public AsteroidsM ast;

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
        CollisionManager.Player(other, explosion, gameObject, ast);
    }
}
