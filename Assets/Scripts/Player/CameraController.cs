using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    [SerializeField] private Transform objectToFollow;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
    }

    public void changeCamera(Transform transformObject)
    {
        objectToFollow = transformObject;
    }
}
