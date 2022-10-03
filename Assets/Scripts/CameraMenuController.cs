using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuController : MonoBehaviour
{
    public float cameraRotSpeed = 3f;

    private void Update()
    {
        transform.Rotate(Vector3.up * cameraRotSpeed * Time.deltaTime);
    }
}
