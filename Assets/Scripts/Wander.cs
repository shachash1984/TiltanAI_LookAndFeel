using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private Vector3 _targetPos;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _rotSpeed = 2f;
    private float _minX, _maxX, _minZ, _maxZ;

    private void Start()
    {
        _minX = -16f;
        _maxX = 16f;
        _minZ = -16f;
        _maxZ = 16f;
        GetNextPosition();
    }

    private void Update()
    {
        if(Vector3.Distance(_targetPos, transform.position) <= 5f)
        {
            GetNextPosition();
        }

        Quaternion tarRot = Quaternion.LookRotation(_targetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, _rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, _movementSpeed * Time.deltaTime));
    }

    private void GetNextPosition()
    {
        _targetPos = new Vector3(Random.Range(_minX, _maxX), 1, Random.Range(_minZ, _maxZ));
    }
}
