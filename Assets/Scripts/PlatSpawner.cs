using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatSpawner : MonoBehaviour {

    public GameObject platforms, bird;
    public float baseTimertoSpawn = 3, baseTimerBird = 10;
    float timerToSpawn, timerSpawnBird;
    public Text birdNext;

    void Update () {
        if (timerToSpawn < baseTimertoSpawn)
        {
            timerToSpawn += Time.deltaTime;
        } else
        {
            int randomPlats = Random.Range(1,8);
            timerToSpawn = 0;
            GameObject plats = Instantiate(platforms, transform.position, transform.rotation);
            switch (randomPlats)
            {
                case 1:
                    plats.transform.GetChild(1).gameObject.SetActive(false);
                    plats.transform.GetChild(2).gameObject.SetActive(false);
                    break;
                case 2:
                    plats.transform.GetChild(0).gameObject.SetActive(false);
                    plats.transform.GetChild(2).gameObject.SetActive(false);
                    break;
                case 3:
                    plats.transform.GetChild(0).gameObject.SetActive(false);
                    plats.transform.GetChild(1).gameObject.SetActive(false);
                    break;
                case 4:
                    plats.transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case 5:
                    plats.transform.GetChild(1).gameObject.SetActive(false);
                    break;
                case 6:
                    plats.transform.GetChild(2).gameObject.SetActive(false);
                    break;
            }
        }

        if (timerSpawnBird < baseTimerBird)
        {
            timerSpawnBird += Time.deltaTime;
            birdNext.text = "Next enemy in: " + (-(timerSpawnBird-baseTimerBird)).ToString();
        }else
        {
            float randomYBird = Random.Range(-4f, 4f);
            timerSpawnBird = 0;
            baseTimerBird = Random.Range(4, 11);
            Instantiate(bird, new Vector2(20, randomYBird), transform.rotation);
        }
	}
}