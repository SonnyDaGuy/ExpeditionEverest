using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Explorer = 0,
    Dog = 1
}


public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;

    [SerializeField] private Transform _carryingHand;

    [SerializeField] private CharacterType _characterType;

    private Player _player;

    private Rigidbody _rigidbody;

    private Vector3 _movementDirection;

    private bool _positiveInput, _negativeInput;

    private Item _carriedItem;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Debug.Log(gameObject.name + ", is using player: " + _player.GetID());
    }

    void Update()
    {
        HandleSwapCharacterInput();
        HandleMovementInput();
        HandleInteractionInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleInteractions();
    }

    void OnTriggerStay(Collider other)
    {
        if (_positiveInput)
        {
            other.GetComponent<Activatable>().Activate(this);
        }
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public void SetCharacterType(CharacterType characterType)
    {
        _characterType = characterType;
    }

    public CharacterType GetCharacterType()
    {
        return _characterType;
    }

    public bool GetInteractButton()
    {
        return _positiveInput;
    }

    public ItemType GetItemType()
    {
        if (_carriedItem)
        {
            return _carriedItem.GetItemType();
        }
        return ItemType.NULL;
    }
    public void TryPickupItem(Item item)
    {
        if (GetItemType() == ItemType.NULL)
        {
            _carriedItem = item;
            item.transform.SetParent(_carryingHand);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            item.MakeItemVisual();
        }
    }

    public void UseItem()
    {
        Destroy(_carryingHand.GetChild(0).gameObject);
    }

    private void HandleInteractions()
    {
        if (_negativeInput)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        if(GetItemType() != ItemType.NULL)
        {
            _carriedItem.MakeItemVisual(false);
            _carryingHand.DetachChildren();
        }
    }

    public Vector3 GetMovementDirection()
    {
        return _movementDirection;
    }

    private void HandleInteractionInput()
    {
        _positiveInput = _player.user.ButtonDownPositive();
        _negativeInput = _player.user.ButtonDownNegative();
    }

    private void HandleMovementInput()
    {
        _movementDirection = _player.user.GetJoystick3D();
    }

    private void HandleSwapCharacterInput()
    {
        if (_player.user.ButtonDownSwapCharacter())
        {
            SwapPlayerWithOtherCharacter();
        }
    }

    private void SwapPlayerWithOtherCharacter()
    {
        Player oldPlayer = _player;
        foreach (CharacterController cController in FindObjectsOfType<CharacterController>())
        {
            if (cController.GetCharacterType() != _characterType)
            {
                _player = cController.GetPlayer();
                cController.SetPlayer(oldPlayer);
            }
        }
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
