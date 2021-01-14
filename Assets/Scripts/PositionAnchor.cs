using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAnchor : MonoBehaviour
{
    [SerializeField] private Transform _anchor;
    [SerializeField] private Vector3 _worldPositionRelativeToAnchor;

    private void Update()
    {
        transform.position = _anchor.position + _worldPositionRelativeToAnchor;
    }
}
