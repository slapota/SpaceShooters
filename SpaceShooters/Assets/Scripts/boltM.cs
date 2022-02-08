using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltM : MonoBehaviour
{
    public GameObject pBolt, player;
    public AudioSource shot;
    public Menu menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            Instantiate(pBolt, player.transform.position + new Vector3(0, 0.7f, 0), pBolt.transform.rotation);
            shot.volume = menu.GetComponent<Menu>().volume;
            shot.Play();
        }
    }
}
