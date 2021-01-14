using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _maxRotSpeed;

    [SerializeField] private Transform _pivotPoint; 

    private List<Player> _players = new List<Player>();

    void Update()
    {
        float totalHorizontalRotateInput = 0f;
        foreach (Player player in _players)
        {
            totalHorizontalRotateInput += player.user.GetRotateHorizontal();
        }

        float angleDifference = Mathf.Lerp(0, totalHorizontalRotateInput, _maxRotSpeed);

        RotatePointAroundPivot(transform.position, _pivotPoint.position, angleDifference * Vector3.right);
        transform.RotateAround(Vector3.zero, Vector3.up, angleDifference);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }

    public void SetPlayers(List<Player> players)
    {
        _players = players;
    }
}
