using UnityEngine;

public class BrakesEffectImmiter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectPrefab;
    [SerializeField] private Transform[] _brakesPoints;
    [SerializeField] private float _duration;

    public void Play()
    {
        for (int i = 0; i < _brakesPoints.Length; i++)
        {
            ParticleSystem particleSystem = Instantiate(_effectPrefab, _brakesPoints[i].position, _brakesPoints[i].rotation, _brakesPoints[i]);
            Destroy(particleSystem.gameObject, _duration);
        }
    }
}
