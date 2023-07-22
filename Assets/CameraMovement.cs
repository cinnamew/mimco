using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    Camera camera;
    [SerializeField] Vector3 resetCameraPos;

    Vector3 difference;
    Vector3 origin;

    bool drag;

    public float zoomRate;
    [SerializeField] Vector2 minmaxZoom;
    [SerializeField] float startingZoom;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        resetCameraPos = camera.transform.position;
        if (startingZoom != 0)
        {
            camera.orthographicSize = startingZoom;
        }
        else
        {
            Debug.LogError("Strating zoom is not set");
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        DragMovementManagment();
        ZoomManagment();
    }

    private void ZoomManagment()
    {
        float addedSize = -Input.mouseScrollDelta.y * zoomRate;
        if (camera.orthographicSize + addedSize > minmaxZoom.x && camera.orthographicSize + addedSize < minmaxZoom.y)
        {
            camera.orthographicSize += addedSize;
        }
    
    }

    private void DragMovementManagment()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (camera.ScreenToWorldPoint(Input.mousePosition)) - camera.transform.position;
            if (!drag)
            {
                drag = true;
                origin = camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
            camera.transform.position = origin - difference;
        }
    }
}
