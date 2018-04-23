using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advance : MonoBehaviour {

    Transform XTarget;
    public float speed = 1, speedOffset;

    private void Start()
    {
        speed = GameObject.Find("Ninja").GetComponent<NinjaMove>().advanceSpeed;
        XTarget = GameObject.Find("TargetMovingObjects").transform;
    }

    void Update () {
        Vector2 XPosLevel = new Vector2(XTarget.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, XPosLevel, speed + speedOffset);

        if (transform.position.x <= XPosLevel.x)
        {
            Destroy(gameObject);
        }
    }
}
