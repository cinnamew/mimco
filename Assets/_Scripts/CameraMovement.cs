using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    Camera camera;
    [SerializeField] Vector3 resetCameraPos;

    Vector3 difference;
    Vector3 origin;

    [SerializeField] Vector2 minmaxMapWithLimit;
    [SerializeField] Vector2 minmaxMapHeightLimit;

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
        ZoomInOut(addedSize);
    }

    private void DragMovementManagment()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(2))
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
            camera.transform.position = new Vector3(
      Mathf.Clamp(camera.transform.position.x, minmaxMapWithLimit.x, minmaxMapWithLimit.y),
        Mathf.Clamp(camera.transform.position.y, minmaxMapHeightLimit.x, minmaxMapHeightLimit.y), transform.position.z);
        }
    }

    public void ZoomInOut(float zoom) 
    {
        if (camera.orthographicSize + zoom > minmaxZoom.x && camera.orthographicSize + zoom < minmaxZoom.y)
            {
                camera.orthographicSize += zoom;
            }
    }
}
