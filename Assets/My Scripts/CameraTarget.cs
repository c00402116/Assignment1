using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public GameObject target;
    public float rotateSpeed = 5;
    public Vector3 offset;
    public float lookUpLimit = 10;
    public float lookDownLimit = 60;

    private float mouseX, mouseY, angleX, angleY;
    Quaternion rotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {


        mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(0 , mouseX, 0);

        angleX = target.transform.eulerAngles.y;
        angleY = target.transform.eulerAngles.x;
        angleY = Mathf.Clamp(angleY, -30, 30);

        rotation = Quaternion.Euler(0, angleX, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
