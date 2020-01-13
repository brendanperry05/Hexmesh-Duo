using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionManager : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Cubes")) {
            Manager.Instance.UpdateHealth(-0.05f, col.transform.localPosition);
        } 
    }
}
