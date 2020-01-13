using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int direction = 2;
    public int speed = 6;
    public float rot;
    
    void FixedUpdate() {
        transform.Translate(new Vector3(1, rot, 0) * speed * direction * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider col) {
        this.gameObject.SetActive(false);
    }
}
