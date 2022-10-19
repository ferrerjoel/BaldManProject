using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private new Transform camera;
    public Vector2 Sensibility;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if(hor != 0){
            transform.Rotate(Vector3.up * hor * Sensibility.x);
        }
        
        if(ver != 0){
            float angle = (camera.localEulerAngles.x - ver * Sensibility.y +360) % 360;
            if(angle > 180){
                angle -=360;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
