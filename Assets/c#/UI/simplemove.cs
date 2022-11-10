using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class simplemove : MonoBehaviour, IDragHandler

{
    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += (Vector3)eventData.delta;
    }
}
