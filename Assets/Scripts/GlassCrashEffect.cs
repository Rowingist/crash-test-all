using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCrashEffect : MonoBehaviour
{
    [SerializeField] private List<GlassPart> _partsOfGlass;
    [SerializeField] private PartDeformation[] _makeAffectionParts;
    [SerializeField] private GameObject[] _completeGlass;

    private void Awake()
    {
        for (int i = 0; i < _makeAffectionParts.Length; i++)
        {
            _makeAffectionParts[i].Hit += OnPlay;
        }

        for (int i = 0; i < _partsOfGlass.Count; i++)
        {
            _partsOfGlass[i].gameObject.SetActive(false);
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
        for (int i = 0; i < _completeGlass.Length; i++)
        {
            _completeGlass[i].SetActive(false);
        }
        for (int i = 0; i < _partsOfGlass.Count; i++)
        {
            _partsOfGlass[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < _partsOfGlass.Count; i++)
        {
            if (_partsOfGlass[i])
            {
                _partsOfGlass[i].Crash();
                Destroy(_partsOfGlass[i].gameObject, 5f);
                _partsOfGlass.Remove(_partsOfGlass[i]);
            }
        }
    }
}
