using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _flyForwardForce;
    [SerializeField] private float _flyUpwardsForce;
    [SerializeField] private float _flySideForce;
    [SerializeField] private Collider _collider;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out CarMovementHandler car))
        {
            float relativePositionX = transform.position.x - car.transform.position.x;
            Vector3 flyDirection = Vector3.up * _flyUpwardsForce + Vector3.forward * _flyForwardForce;
            if (relativePositionX >= 0)
                flyDirection += Vector3.right;
            else
                flyDirection -= Vector3.right;

            RagdollSwitcher ragdollSwitcher = GetComponentInParent<RagdollSwitcher>();
            if (ragdollSwitcher)
            {
                _collider.isTrigger = true;
                ragdollSwitcher.MakePhysical();
                ragdollSwitcher.GetSpine().AddForce(flyDirection, ForceMode.VelocityChange);
            }
            else
            {
                _rigidbody.AddForce(flyDirection, ForceMode.VelocityChange);
                _collider.isTrigger = true;
            }
            Destroy(gameObject, 2f);
        }   
    }
}
