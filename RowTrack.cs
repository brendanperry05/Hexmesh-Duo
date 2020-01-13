using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowTrack : MonoBehaviour
{
    private int row;
    CubeSpawner spawnerScript;
    DoubleSpawner doubleS;
    ScriptedSpawner scripted;
    Rigidbody rigid;
    public Material[] materials;
    public Color[] colors;
    public GameObject leftBomb;
    public GameObject rightBomb;
    public GameObject healthParticles;
    public GameObject bombParticles;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }
    void OnDisable() {
        if(spawnerScript != null) {
            spawnerScript.Remove(row, this.gameObject);
        }

        if(scripted != null) {
            scripted.Remove(row, this.gameObject);
        }

        if(doubleS != null) {
            doubleS.Remove(row, this.gameObject);
        }
    }

    public void SetRow(int num, CubeSpawner spawner, ScriptedSpawner s, DoubleSpawner d) {
        row = num;
        spawnerScript = spawner;
        doubleS = d;
        scripted = s;
    }

    public int GetRow() {
        return row;
    }

    void FixedUpdate() {
        rigid.AddForce(Vector3.down * 50);
    }

    public void OnTriggerEnter(Collider col) {
        int num = 0;
        Color matColor = GetComponent<Renderer>().material.color;
        for(int i = 0; i < colors.Length; i++) {
            if(colors[i] == matColor) {
                num = i;
            }
        }
                  
        if(num == 0 && col.CompareTag("color1")) {
            ScoreManager.Instance.AddScore(1, 0, transform.position);
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }
            gameObject.SetActive(false);
        }
        else if(num == 1 && col.CompareTag("color2")) {
            ScoreManager.Instance.AddScore(1, 1, transform.position);
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }
            gameObject.SetActive(false);
        }
        else if(num == 2 && col.CompareTag("color3")) {
            ScoreManager.Instance.AddScore(1, 2, transform.position);
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }
            gameObject.SetActive(false);
        }
        else if(num == 3) {
            // bombs
            if(transform.position.x > 0) {
               Instantiate(rightBomb, transform.position, Quaternion.identity);
               Instantiate(bombParticles, transform.position, Quaternion.Euler(-5, 90, 0));
            } else {
               Instantiate(leftBomb, transform.position, Quaternion.identity);
               Instantiate(bombParticles, transform.position, Quaternion.Euler(-5, -90, 0));
            }

            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }

            if(col.CompareTag("Barrier")) {
                Manager.Instance.UpdateHealth(-1.0f, transform.localPosition);
            }
            gameObject.SetActive(false);
        }
        else if(num == 4) {
            // health
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }

            if(Manager.Instance.GetHealth() < 1) {
                Manager.Instance.HealhBlock(transform.localPosition);
                Instantiate(healthParticles, transform.position, Quaternion.identity);
            }
            else {
                ScoreManager.Instance.ScoreBlock(transform.position);
            }
            gameObject.SetActive(false);
        }
        else if(col.CompareTag("Bomb")) {
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }
            ScoreManager.Instance.AddScore(1, 3, transform.position);
            gameObject.SetActive(false);
        }
        else if(col.CompareTag("Barrier")) {
            Manager.Instance.UpdateHealth(-.05f, transform.localPosition);
            if(spawnerScript == null) {
                if(scripted == null) {
                    doubleS.EnableExplosion(transform.position, materials[num]);
                } 
                else {
                    scripted.EnableExplosion(transform.position, materials[num]);
                }
            } else {
                spawnerScript.EnableExplosion(transform.position, materials[num]);
            }
            gameObject.SetActive(false);
        }
    }
}
