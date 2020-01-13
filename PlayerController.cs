using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Transform leftPlayer;
    public Transform rightPlayer;
    GraphicRaycaster ray;
    GraphicRaycaster raycaster;
    PointerEventData pointer;
    EventSystem eventSystem;
    
    void Start() {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        /*if (Application.isEditor)
        {
            if (Input.GetMouseButton(0))
            {
                float y = Input.mousePosition.y - (Screen.height / 2);
                float percentage = y / (Screen.height / 2);
                float yPos = .45f * percentage * 2;
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    leftPlayer.localPosition = new Vector3(-0.475f, Mathf.Clamp(yPos, -.45f, .45f), -1f);
                }
                else
                {
                    rightPlayer.localPosition = new Vector3(0.475f, Mathf.Clamp(yPos, -.45f, .45f), -1f);
                }
            }
        } else
        {*/
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    pointer = new PointerEventData(eventSystem);
                    pointer.position = Input.GetTouch(i).position;

                    List<RaycastResult> results = new List<RaycastResult>();

                    raycaster.Raycast(pointer, results);

                    if (results.Count == 0)
                    {
                        float y = Input.touches[i].position.y - (Screen.height / 2);
                        float percentage = y / (Screen.height / 2);
                        float yPos = .45f * percentage * 2;

                        if (Input.touches[i].position.x < Screen.width / 2)
                        {
                            leftPlayer.localPosition = new Vector3(-0.475f, Mathf.Clamp(yPos, -.45f, .45f), -1f);
                        }
                        else
                        {
                            rightPlayer.localPosition = new Vector3(0.475f, Mathf.Clamp(yPos, -.45f, .45f), -1f);
                        }
                    }
                }
            }
        }
    }
//} 