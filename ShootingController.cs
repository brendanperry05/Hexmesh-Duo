using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public GameObject ball;
    public int numberOfBallsToSpawn = 10;
    public float spawnRate = .5f;
    private GameObject[] balls;
    private MeshRenderer[] renderers;
    public Color[] colors;
    public GameObject color1;
    public GameObject color2;
    public GameObject color3;

    void Awake() {
        balls = new GameObject[numberOfBallsToSpawn];
        renderers = new MeshRenderer[numberOfBallsToSpawn];

        for(int i = 0; i < numberOfBallsToSpawn; i++) {
            balls[i] = Instantiate(ball, transform.position, transform.rotation);
            renderers[i] = balls[i].GetComponent<MeshRenderer>();
            balls[i].SetActive(false);
        }
    }

    private void Start() {
        StartGame();
    }

    public void StartGame() {
        InvokeRepeating("SpawnBalls", 1f, spawnRate);
    }

    public void Resume() {
        InvokeRepeating("SpawnBalls", 0f, spawnRate);
    }

    void SpawnBalls() {
        for(int i = 0; i < numberOfBallsToSpawn; i++) {
            if(balls[i].activeInHierarchy == false) {
                balls[i].transform.position = transform.position;
                if(color1.activeInHierarchy) {
                    renderers[i].material.color = colors[0];
                    balls[i].tag = "color1";
                } else if (color2.activeInHierarchy) {
                    renderers[i].material.color = colors[1];
                    balls[i].tag = "color2";
                } else {
                    renderers[i].material.color = colors[2];
                    balls[i].tag = "color3";
                }
                balls[i].SetActive(true);
                break;
            }
        }
    }

    public void SUPER() {
        for(int i = 0; i < numberOfBallsToSpawn; i++) {
            if(balls[i].activeInHierarchy == false) {
                balls[i].transform.position = transform.position;
                if(color1.activeInHierarchy) {
                    renderers[i].material.color = Color.black;
                    balls[i].tag = "Bomb";
                } else if (color2.activeInHierarchy) {
                    renderers[i].material.color = Color.black;
                    balls[i].tag = "Bomb";
                } else {
                    renderers[i].material.color = Color.black;
                    balls[i].tag = "Bomb";
                }
                balls[i].SetActive(true);
                break;
            }
        }
    }
}
