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
