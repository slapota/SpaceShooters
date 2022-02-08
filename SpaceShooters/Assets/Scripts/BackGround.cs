using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    bool Pos() => transform.position.y < -29.7f;

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        transform.position += (Vector3.down * speed * Time.deltaTime);
    }

    IEnumerator Move()
    {
        yield return new WaitUntil(Pos);
        transform.position = new Vector3(0, 30, 0);
        StartCoroutine(Move());
    }
}
