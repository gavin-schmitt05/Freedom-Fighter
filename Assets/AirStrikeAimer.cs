using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeAimer : MonoBehaviour, ISpecialSlotInterface
{
    [SerializeField] private Texture2D airStrikeCursor;

    public GameObject airStrike; // Airstrike bomb prefab

    private float originalCameraSize;

    private bool afterInstantiate; // Had to use this bool because the effects were changing whenever I put the binoculars in the inventory slot, while it was deactivated

    void Start()
    {
        originalCameraSize = (float)Camera.main.orthographicSize;
        CameraController.instance.changeCameraZoom(15); // Changes FOV when the aimer is activated
        Cursor.SetCursor(airStrikeCursor, Vector2.zero, CursorMode.Auto); // Sets cursor to red line
        afterInstantiate = true;
    }

    void OnEnable()
    {
        if (afterInstantiate)
        {
            Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //Initiates where airstrike will land
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Takes mouse click position
            mouseWorldPos.z = (float)0.0; // Rotates bombs properly
            Instantiate(airStrike, airStrike.transform.position = new Vector3(mouseWorldPos.x - 5, 120, 0), airStrike.transform.rotation);// Drops bombs at different heights, this way it looks like they are being dropped in increments
            Instantiate(airStrike, airStrike.transform.position = new Vector3(mouseWorldPos.x - 8, 130, 0), airStrike.transform.rotation);
            Instantiate(airStrike, airStrike.transform.position = new Vector3(mouseWorldPos.x, 140, 0), airStrike.transform.rotation);
            Instantiate(airStrike, airStrike.transform.position = new Vector3(mouseWorldPos.x + 5, 150, 0), airStrike.transform.rotation);
            Instantiate(airStrike, airStrike.transform.position = new Vector3(mouseWorldPos.x + 8, 160, 0), airStrike.transform.rotation);
            CameraController.instance.changeCameraZoom((int)originalCameraSize);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SpecialSlotInventoryManager.instance.RemoveSpecial(true);
            Destroy(this.gameObject);
        }
    }

    public void OnDeactivate()
    {
        CameraController.instance.changeCameraZoom((int)originalCameraSize);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
