using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityZone : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float _affectionTime;
    [SerializeField] private bool _isAccelerator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PrometeoCarController carController))
        {
            Destroy(gameObject);
            StartCoroutine(DecelerateCar(_affectionTime, carController));
        }
    }

    private IEnumerator DecelerateCar(float actionTime, PrometeoCarController carController)
    {
        float time = 0;
        while (time < 1)
        {
            if (_isAccelerator)
                carController.MoveForward(2);
            else
                carController.DecelerateCar();

            time += Time.deltaTime / actionTime;
            yield return null;
        }
    }
}
