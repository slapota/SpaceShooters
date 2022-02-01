using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(transform.position.z < -26.35f)
        {
            transform.position = pos;
        }
    }
}
