using System.Collections.Generic;
using UnityEngine;

public class DustEffectsTrigger : MonoBehaviour
{
    [SerializeField] private List<Transform> _dustEffectPositions;
    [SerializeField] private ParticleSystem _dustffect;

    public void PlayEffect()
    {
        for (int i = 0; i < _dustEffectPositions.Count; i++)
        {
            Instantiate(_dustffect, _dustEffectPositions[i].position, Quaternion.identity, _dustEffectPositions[i]);
            Destroy(_dustEffectPositions[i].gameObject, 0.4f);
            _dustEffectPositions.Remove(_dustEffectPositions[i]);
        }
    }
}
