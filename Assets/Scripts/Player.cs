using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 1;
    Vector2 moveInput;

    Camera mainCam;
    Vector3 eyeLookPoint;

    public Gun gun;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        eyeLookPoint = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // look at mouse
        Ray CameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane eyePlane = new Plane(Vector3.up, transform.position);

        if (eyePlane.Raycast(CameraRay, out float cameraDist))
        {
            Vector3 lookPoint = CameraRay.GetPoint(cameraDist);
            eyeLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(eyeLookPoint);
        }

        if(Input.GetButton("Fire1"))
        {
            gun?.Fire(eyeLookPoint);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(moveInput.x, 0, moveInput.y), Time.fixedDeltaTime * moveSpeed);
    }
}
