using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _maxRotSpeed;

    private List<Player> _players = new List<Player>();

    void Update()
    {
        float totalHorizontalRotateInput = 0f;
        foreach (Player player in _players)
        {
            totalHorizontalRotateInput += player.user.GetRotateHorizontal();
        }

        float angleDifference = Mathf.Lerp(0, totalHorizontalRotateInput, _maxRotSpeed);
        transform.RotateAround(Vector3.zero, Vector3.right, angleDifference);
    }

    public void SetPlayers(List<Player> players)
    {
        _players = players;
    }
}
