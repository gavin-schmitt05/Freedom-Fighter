using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this; // Creates instance of script to be accessed from anywhere
    }
    [SerializeField] private Transform objectToFollow; // Transform for what object the camera is following


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z); // Keeps camera in motion with object its following
        // -------------------Code for Zooming Out------------
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 125)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 7)
                Camera.main.orthographicSize += 0.5f;

        }
        // ---------------Code for Zooming In------------------------
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1.5)
                Camera.main.orthographicSize -= 0.5f;
        }
    }

    public void changeCamera(Transform transformObject) // Used in other scripts (Player, mech, etc.) to change what the camera is following
    {
        objectToFollow = transformObject;
    }

    public void changeCameraZoom(int zoom) // Used to change the zoom scale of the camera
    {
        camera.orthographicSize = zoom;
    }
}
