using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightPositioner : MonoBehaviour
{
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _startPosition.y, transform.position.z);
    }
}
