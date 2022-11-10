using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pinchswipe : MonoBehaviour
{

    float touchDist = 0;
    float lastDist = 0;
    Vector3 currentDirection;
    public bool dragging = false;


    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        checkinput();
    }

    void checkinput()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (dragging==false && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        currentDirection = touch.deltaPosition * 0.15f;
                        cam.transform.position -= (currentDirection * 1.5f * cam.orthographicSize/269);
                        break;

                    case TouchPhase.Stationary:
                        cam.transform.position -= (currentDirection *1.5f* cam.orthographicSize / 269);
                        break;

                    default:
                        currentDirection = Vector2.zero;
                        break;
                }
                if (cam.transform.position.x <= 1527)
                    cam.transform.position = new Vector3(1528, cam.transform.position.y, -10);
                if (cam.transform.position.x >= 2693)
                    cam.transform.position = new Vector3(2662, cam.transform.position.y, -10);
                if (cam.transform.position.y <= 2020)
                    cam.transform.position = new Vector3(cam.transform.position.x, 2021, -10);
                if (cam.transform.position.y >= 3132)
                    cam.transform.position = new Vector3(cam.transform.position.x, 3131, -10);
            }
        }
        else if (Input.touchCount == 2)
        {

            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);
            if (dragging == false && !EventSystem.current.IsPointerOverGameObject(tZero.fingerId) && !EventSystem.current.IsPointerOverGameObject(tOne.fingerId))
            {
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                float deltaDistance = oldTouchDistance - currentTouchDistance;
                if (cam.orthographicSize <= 700 && cam.orthographicSize >= 77)
                    cam.orthographicSize += deltaDistance * 0.2f;
                if (cam.orthographicSize <= 77)
                    cam.orthographicSize = 78;
                if (cam.orthographicSize >= 700)
                    cam.orthographicSize = 699;
                /*if (deltaDistance > 0 && rt.rect.height > 2055.57f)
                    cam.transform.sizeDelta = new Vector2((rt.rect.width) - (deltaDistance * 3000f) / 1465, (rt.rect.height) - (deltaDistance * 3000f) / 2048);
                else if (deltaDistance < 0 && rt.rect.height < 19203.02f)
                    cam.transform.sizeDelta = new Vector2((rt.rect.width) - (deltaDistance * 3000f) / 1465, (rt.rect.height) - (deltaDistance * 3000f) / 2048);
                if (cam.transform.height < 2055.57f)
                    cam.transform.sizeDelta = new Vector2(3792.199f, 2055.57f);
                if (cam.transform.height > 19203.02f)
                    cam.transform.sizeDelta = new Vector2(27925.29f, 19203.02f);
                */
            }
        }
    }
    
}
