using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;

    private Player _player;

    private Rigidbody _rigidbody;

    private Vector3 _movementDirection;

    private bool _interactInput;

    private PickupType _itemBeingHeld;

    public enum PickupType
    {
        torch = 0,
        pickaxe = 1
    }
    public enum CharacterType
    {
        Explorer = 0,
        Dog = 1
    }

    public void AssignPlayer(Player.ID playerID)
    {
        _player = Players.GetPlayer(playerID);
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        AssignPlayer(Player.ID.player0); //temp
    }

    void Update()
    {
        HandleMovementInput();
        HandleInteractionInputs();
    }

    void PickupItem(GameObject itemToPickup, PickupType pickupType)
    {
        _itemBeingHeld = pickupType;
    }

    public bool GetInteractButton()
    {
        return _interactInput;
    }

    public Vector3 GetMovementDirection()
    {
        return _movementDirection;
    }

    private void HandleInteractionInputs()
    {
        _interactInput = _player.user.ButtonDownPositive();
    }

    private void HandleMovementInput()
    {
        _movementDirection = _player.user.GetJoystick3D();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _rigidbody.MovePosition(transform.position + _movementDirection * _movementSpeed);
        HandleLookRotation();
    }

    private void HandleLookRotation()
    {
        if(_movementDirection != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, _movementDirection, _rotationSpeed);
        }
    }
}
