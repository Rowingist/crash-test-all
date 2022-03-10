using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodies;

    private void Awake()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = true;
        }
    }

    public void MakePhysical()
    {
        _animator.enabled = false;
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = false;
        }
    }

    public Rigidbody GetSpine()
    {
        return _allRigidbodies[0];
    }
}
