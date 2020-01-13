using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    public int cubeDirection = 1;
    public Transform plane;
    public int spawnAmount = 100;
    public float spawnRate = 1f;
    [Tooltip("Lower is more")]
    public int specialBlockSpawnRatio = 25;
    int amountSpawned = 1;

    public Color[] colors;
    private Color[] colorGrid;
    private int[] sizeGrid;

    private GameObject[] cubes;
    private GameObject[] explosions;
    public GameObject explosion;
    public GameObject[] column1;
    public int explosionAmount = 50;

    private List<List<GameObject>> stacks = new List<List<GameObject>>();
    private List<GameObject> stack1 = new List<GameObject>();
    private List<GameObject> stack2 = new List<GameObject>();
    private List<GameObject> stack3 = new List<GameObject>();
    private List<GameObject> stack4 = new List<GameObject>();
    private List<GameObject> stack5 = new List<GameObject>();
    private List<GameObject> stack6 = new List<GameObject>();
    private List<GameObject> stack7 = new List<GameObject>();
    private List<GameObject> stack8 = new List<GameObject>();
    private List<GameObject> stack9 = new List<GameObject>();
    private List<GameObject> row1 = new List<GameObject>();
    private List<GameObject> row2 = new List<GameObject>();
    private List<GameObject> row3 = new List<GameObject>();
    private List<GameObject> row4 = new List<GameObject>();
    private List<GameObject> row5 = new List<GameObject>();
    private List<GameObject> row6 = new List<GameObject>();
    private List<GameObject> row7 = new List<GameObject>();
    private List<GameObject> row8 = new List<GameObject>();
    private List<GameObject> row9 = new List<GameObject>();
    private List<List<GameObject>> rows = new List<List<GameObject>>();
    public Manager manager;

    public string path;
    StreamWriter sw;

    // Start is called before the first frame update
    void Start()
    {
        sw = new StreamWriter(path, true);

        rows.Add(row1);
        rows.Add(row2);
        rows.Add(row3);
        rows.Add(row4);
        rows.Add(row5);
        rows.Add(row6);
        rows.Add(row7);
        rows.Add(row8);
        rows.Add(row9);

        stacks.Add(stack1);
        stacks.Add(stack2);
        stacks.Add(stack3);
        stacks.Add(stack4);
        stacks.Add(stack5);
        stacks.Add(stack6);
        stacks.Add(stack7);
        stacks.Add(stack8);
        stacks.Add(stack9);

        colorGrid = new Color[9];
        sizeGrid = new int[9];
        cubes = new GameObject[spawnAmount];
        explosions = new GameObject[spawnAmount];

        for(int i = 0; i < spawnAmount; i++) {
            GameObject obj = Instantiate(cube);
            obj.SetActive(false);
            cubes[i] = obj;
        }

        for(int i = 0; i < explosionAmount; i++) {
            GameObject exp = Instantiate(explosion);
            exp.SetActive(false);
            explosions[i] = exp;
        }
    }

    void WriteToFile(string info) {
        //sw.Write("\"" + info + "\", ");
    }

    public void CloseTextFile() {
        sw.Close();
    }

    public void StartGame() {
        manager.ResetHealth();
        InvokeRepeating("Spawn", 3f, spawnRate);
    }

    public void Resume() {
        Time.timeScale = 1;
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn() {
        int randColor = Random.Range(0, colors.Length);
        int rand = Random.Range(0, 9);

        for(int i = 0; i < spawnAmount; i ++) {
            if(cubes[i].activeInHierarchy == false) {
                Rigidbody rigid = cubes[i].GetComponent<Rigidbody>();
                
                rigid.velocity = new Vector3(0, 0, 0);
                rigid.angularVelocity = new Vector3(0, 0, 0);
                cubes[i].SetActive(true);

                Color color;

                if(amountSpawned % specialBlockSpawnRatio != 0) {
                    color = colors[randColor];
                } else {
                    int specialRand = Random.Range(0, 2);

                    if(specialRand == 0) {
                        color = Color.black;
                        randColor = 3;
                    } else {
                        color = Color.white;
                        randColor = 4;
                    }
                }

                WriteToFile(rand.ToString() + randColor.ToString());

                cubes[i].GetComponent<Renderer>().material.color = color;

                if(colorGrid[rand] == color || colorGrid[rand] == Color.clear) {
                    cubes[i].transform.SetParent(plane);
                    cubes[i].layer = LayerMask.NameToLayer("row" + (rand + 1).ToString());
                    cubes[i].GetComponent<RowTrack>().SetRow(rand, this, null, null);
                    cubes[i].transform.localPosition = new Vector3(column1[rand].transform.localPosition.x, column1[rand].transform.localPosition.y, column1[rand].transform.localPosition.z + (column1[rand].transform.localPosition.z * sizeGrid[rand]));
                    cubes[i].transform.localScale = column1[rand].transform.localScale;
                    cubes[i].transform.rotation = column1[rand].transform.rotation;
                    rows[rand].Add(cubes[i]);
                    colorGrid[rand] = color;
                    stacks[rand].Add(cubes[i]);
                    sizeGrid[rand] ++;
                    break;
                } else {
                    int max = rows[rand].Count;

                    for(int k = max -1; k >=0; k--) {
                       rows[rand][k].gameObject.transform.localPosition = new Vector3(rows[rand][k].gameObject.transform.localPosition.x - (.05f * cubeDirection), rows[rand][k].gameObject.transform.localPosition.y, rows[rand][k].gameObject.transform.localPosition.z);
                    }

                    cubes[i].transform.SetParent(plane);
                    cubes[i].layer = LayerMask.NameToLayer("row" + (rand + 1).ToString());
                    cubes[i].GetComponent<RowTrack>().SetRow(rand, this, null, null);
                    cubes[i].transform.localPosition = new Vector3(column1[rand].transform.localPosition.x, column1[rand].transform.localPosition.y, column1[rand].transform.localPosition.z);
                    cubes[i].transform.localScale = column1[rand].transform.localScale;
                    cubes[i].transform.rotation = column1[rand].transform.rotation;
                    rows[rand].Add(cubes[i]);
                    colorGrid[rand] = color;
                    stacks[rand].Clear();
                    stacks[rand].Add(cubes[i]);
                    sizeGrid[rand] = 1;
                } 
                break;
            }
        }
        amountSpawned++;
    }

   public void Remove(int row, GameObject obj) {
       rows[row].Remove(obj);
       if(stacks[row].Contains(obj)) {
           stacks[row].Remove(obj);
           sizeGrid[row] --;
       }
   }

   public void EnableExplosion(Vector3 location, Material material) {
       for(int i = 0; i < explosions.Length; i++) {
           if(!explosions[i].gameObject.activeInHierarchy) {
               explosions[i].transform.position = location;
               ParticleSystem ps = explosions[i].GetComponent<ParticleSystem>();
               var main = ps.main;
               ps.GetComponent<Renderer>().material = material;
               explosions[i].SetActive(true);
               ps.Clear();
               ps.Play();
               break;
           }
       }
   }
}
