using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelCollider;
    [SerializeField] private Transform _target;
    [SerializeField] private SkinnedMeshRenderer _wheelAxis;
    [SerializeField] private GameObject _bubble;

    private Mesh _mesh;

    [SerializeField] private float timer = 0.1f;
    private float elapsedTime;

    private void Start()
    {
        _mesh = new Mesh();
        StartCoroutine(FindVertex());
    }

    //private void FixedUpdate()
    //{
    //    _wheelCollider.transform.position = _target.position;




    //}

    private IEnumerator FindVertex()
    {

            _wheelAxis.BakeMesh(_mesh, true);
        for (int i = 0; i < _mesh.vertices.Length; i++)
        {
            Matrix4x4 localToWorld = transform.localToWorldMatrix;
            Vector3[] vertices = _mesh.vertices;
            Vector3 worldVertex = localToWorld.MultiplyPoint3x4(vertices[i]);

            _bubble.transform.position = worldVertex;
            print(i);
            yield return new WaitForSeconds(timer);
        }

    }

}
