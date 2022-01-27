using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hranice : MonoBehaviour
{
    private Vector2 screenBounds;
    private float ���ka;
    private float v��ka;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ���ka = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        v��ka = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + ���ka, screenBounds.x * -1 - ���ka);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + v��ka, screenBounds.y * -1 - v��ka);
        transform.position = viewPos;
    }
}
