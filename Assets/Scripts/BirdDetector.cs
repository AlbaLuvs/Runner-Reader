using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdDetector : MonoBehaviour {

    public Text birdNear, birdPosX, birdPosY, birdToPlayer;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "EndGame":
                Transform bird = collision.transform;
                birdNear.text = "Enemy Information: Approaching";
                birdPosX.text = "Enemy X Pos: " + bird.position.x.ToString();
                birdPosY.text = "Enemy Y Pos: " + bird.position.y.ToString();
                birdToPlayer.text = "Distance from player: " + (bird.position.x - player.position.x).ToString();

                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "EndGame":

                birdNear.text = "Enemy Information: No Sighting";
                birdPosX.text = "Enemy X Pos: -";
                birdPosY.text = "Enemy Y Pos: -";
                birdToPlayer.text = "Distance from player: -";

                break;
        }
    }
}
