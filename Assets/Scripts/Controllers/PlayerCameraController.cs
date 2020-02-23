using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float BorderThickness;
    [SerializeField]
    private Vector2 CameraLimit; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        //mouse.position is measured from bottom left corner of screen
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - BorderThickness)
        {
            pos.y += Speed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= BorderThickness)
        {
            pos.y -= Speed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - BorderThickness)
        {
            pos.x += Speed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= BorderThickness)
        {
            pos.x -= Speed * Time.deltaTime;
        }

        //LIMIT CAMERA MOVEMENT
        pos.x = Mathf.Clamp(pos.x, -CameraLimit.x, CameraLimit.x);
        pos.y = Mathf.Clamp(pos.y, -CameraLimit.y, CameraLimit.y);
        //Move camera
        transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
