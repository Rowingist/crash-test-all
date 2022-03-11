using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorDeactivation : MonoBehaviour
{
    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
