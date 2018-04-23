using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour {

    Transform player;
    BoxCollider2D platCollider;

    private void Start()
    {
        platCollider = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Ninja").transform;
    }

    void Update () {
        if (transform.position.y < (player.position.y - 0.8f))
        {
            if (platCollider.isTrigger != false)
            {
                platCollider.isTrigger = false;
            }
        }

        if (transform.position.y > (player.position.y - 0.5f))
        {
            if (platCollider.isTrigger != true)
            {
                platCollider.isTrigger = true;
            }
        }
	}
}
