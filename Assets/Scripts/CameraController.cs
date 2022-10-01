using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float inputScroll;

    private float rotX;
    private float rotY;

    private float lookXLimit = 70.0f;

    private Vector3 smoothVelocity;
    private Vector3 currentRotation;

    [SerializeField]
    private float distanceToTarget = 1.0f;

    [SerializeField]
    private float smoothTime = 0.1f;

    [SerializeField]
    private float mouseSensitivity = 5.0f;

    [SerializeField]
    private float minDistToTarget = 1.0f;

    [SerializeField]
    private float maxDistToTarget = 5.0f;

    [SerializeField]
    private float cameraDistanceChangeMultiplier = 0.1f;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerInput();
        CameraMovement();

        if (inputScroll != 0)
        {
            ChangeCameraDistance();
        }
    }

    void PlayerInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        inputScroll = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    void CameraMovement()
    {
        // Ќахождени€ угла поворота камеры в градусах
        rotX += mouseX * mouseSensitivity;
        rotY += mouseY * mouseSensitivity;

        // Ѕлокирование угла поворота камеры по X координате
        rotY = Mathf.Clamp(rotY, -lookXLimit, lookXLimit);

        Vector3 nextRotation = new Vector3(-rotY, rotX);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceToTarget;
    }

    void ChangeCameraDistance()
    {
        distanceToTarget += -inputScroll * cameraDistanceChangeMultiplier;
        distanceToTarget = Mathf.Clamp(distanceToTarget, minDistToTarget, maxDistToTarget);
    }

    public float GetCameraCurrentDistance()
    {
        return distanceToTarget;
    }

    public float GetXRotation()
    {
        return rotX;
    }
}
