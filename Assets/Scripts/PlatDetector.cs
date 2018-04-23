using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatDetector : MonoBehaviour {

    public Text nextPlatSet, nearPos, midPos, farPos;
    public Text upPlat, midPlat, lowPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Ground":
                Transform nextPlatforms = collision.transform;
                int childCount = nextPlatforms.GetComponentsInChildren<Transform>().GetLength(0) - 1;
                nextPlatSet.text = "Next Platform Set: " + childCount;

                for (int x = 0; x < 3; x++)
                {
                    if (nextPlatforms.GetChild(x).gameObject.activeSelf)
                    {
                        switch (nextPlatforms.GetChild(x).name)
                        {
                            case "UpperPlat":
                                upPlat.text = "Upper platform?  YES";
                                break;
                            case "MidPlat":
                                midPlat.text = "Middle platform?  YES";
                                break;
                            case "LowPlat":
                                lowPlat.text = "Lower platform?  YES";
                                break;
                        }
                    }
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Ground":
                Transform nextPlatforms = collision.transform;
                nearPos.text = "Nearest point Pos: " + (nextPlatforms.position.x - 7).ToString();
                midPos.text = "Middle point Pos: " + nextPlatforms.position.x.ToString();
                farPos.text = "Farthest Point Pos: " + (nextPlatforms.position.x + 7).ToString();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Ground":
                nearPos.text = "Nearest point Pos: -";
                midPos.text = "Middle point Pos: -";
                farPos.text = "Farthest Point Pos: -";

                upPlat.text = "Upper platform? -";
                midPlat.text = "Middle platform? -";
                lowPlat.text = "Lower platform? -";
                break;
        }
    }
}