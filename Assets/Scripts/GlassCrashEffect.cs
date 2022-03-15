using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCrashEffect : MonoBehaviour
{
    [SerializeField] private GlassPart[] _partsOfGlass;
    [SerializeField] private PartDeformation[] _makeAffectionParts;
    [SerializeField] private GameObject _completeGlass;

    private void Awake()
    {
        for (int i = 0; i < _makeAffectionParts.Length; i++)
        {
            _makeAffectionParts[i].Hit += OnPlay;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _makeAffectionParts.Length; i++)
        {
            _makeAffectionParts[i].Hit -= OnPlay;
        }
    }

    private void OnPlay(UnityEngine.Collision collision)
    {
        BurstEffect(collision);
    }

    private void BurstEffect(UnityEngine.Collision collision)
    {
        _completeGlass.SetActive(false);
        for (int i = 0; i < _partsOfGlass.Length; i++)
        {
            _partsOfGlass[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < _partsOfGlass.Length; i++)
        {
            _partsOfGlass[i].GetComponent<Rigidbody>().AddForce(-collision.rigidbody.velocity, ForceMode.VelocityChange);
        }
    }
}
