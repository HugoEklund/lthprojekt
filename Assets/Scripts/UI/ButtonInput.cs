using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private Transform rotObject;
    [SerializeField] private GameObject buttonL;
    [SerializeField] private GameObject buttonR;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch tempTouch = Input.GetTouch(0);

            PointerEventData tempEvent = new PointerEventData(EventSystem.current);
            tempEvent.position = tempTouch.position;

            List<RaycastResult> castResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(tempEvent, castResults);

            RaycastResult rayTarget = castResults.FirstOrDefault(castresult => castresult.gameObject == buttonL || castresult.gameObject == buttonR);

            if (rayTarget.gameObject != null)
            {
                if (rayTarget.gameObject == buttonL && rayTarget.gameObject != buttonR)
                {
                    GameObject.Find("Player").GetComponent<MovementController>().PlayerRot(1f);
                }
                else if (rayTarget.gameObject == buttonR && rayTarget.gameObject != buttonL)
                {
                    GameObject.Find("Player").GetComponent<MovementController>().PlayerRot(-1f);
                }
            }
        }
    }
}