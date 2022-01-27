using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hranice : MonoBehaviour
{
    private Vector2 screenBounds;
    private float šíøka;
    private float výška;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        šíøka = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        výška = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + šíøka, screenBounds.x * -1 - šíøka);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + výška, screenBounds.y * -1 - výška);
        transform.position = viewPos;
    }
}
