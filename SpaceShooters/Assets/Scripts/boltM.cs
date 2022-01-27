using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltM : MonoBehaviour
{
    public GameObject pBolt, player;
    public AudioSource shot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            Instantiate(pBolt, player.transform.position + new Vector3(0, 1.05f, 0), pBolt.transform.rotation);
            shot.Play();
        }
    }
}
