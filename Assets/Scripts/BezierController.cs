using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private List<Transform> _pointsTransform = new List<Transform>();
    private List<Vector3> _pointsPos = new List<Vector3>();
    private bool _check;
    private int _index;
    private float _speed;
    private Vector3[] _arrayPos;

    [Range(0, 1)]
    public float t;

    private void Start()
    {
        _index = 0;
        if (_pointsTransform.Count != 0)
            _pointsTransform.Clear();
        foreach (Transform child in _target)
            _pointsTransform.Add(child);
        _speed = Random.Range(0.0005f, 0.001f);
    }

    void FixedUpdate()
    {
        if (!_check)
        {
            _pointsPos.Add(Bezier.GetPoint(_pointsTransform, t));
            transform.position = _pointsPos[_pointsPos.Count - 1];
        }
        else if (_check)
        {
            transform.position = _arrayPos[_index];
            _index++;
        }
        if (t >= 1)
        {
            t = 0;
            _index = 0;
            _check = true;
            _arrayPos = new Vector3[_pointsPos.Count];
            _pointsPos.CopyTo(0, _arrayPos, 0, _pointsPos.Count);
        }
        t += _speed;
    }
}