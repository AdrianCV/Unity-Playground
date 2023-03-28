using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    private Transform _cameraTransform;

    void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    void LookAtCamera()
    {
        transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, _cameraTransform.up);
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCamera();
    }
}
