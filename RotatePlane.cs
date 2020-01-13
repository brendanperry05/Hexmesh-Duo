using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public Transform leftPlayer;
    public Transform rightPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(30.0f - leftPlayer.localPosition.y * 2 - rightPlayer.localPosition.y * 2, 10.0f, 5.0f);
    }
}
