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

    [SerializeField] private GameObject _pointLight;

    private Animator _animator;

    private Player _player;

    private Rigidbody _rigidbody;

    private Vector3 _movementDirection;

    private bool _positiveInput, _negativeInput;

    private Item _carriedItem;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
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

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Activatable>().EnableOutline(true ,this);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Activatable>().EnableOutline(false, this);
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

    public Item GetItem()
    {
        return _carriedItem;
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
            _pointLight.SetActive(GetItemType() == ItemType.torchLit);
            _carriedItem = item;
            item.EnableOutline(false, this);
            item.transform.SetParent(_carryingHand);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            item.MakeItemVisual();
        }
    }

    public void UseItem()
    {
        DestroyItemInfoInPlayer();
        Destroy(_carryingHand.GetChild(0).gameObject);
    }

    private void DestroyItemInfoInPlayer()
    {
        _pointLight.SetActive(false);
        _carriedItem = null;
    }

    public void LightUpPlayer(bool on = true)
    {
        _pointLight.SetActive(on);
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
            DestroyItemInfoInPlayer();
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
        _animator.SetBool("IsMoving", _player.user.GetJoystick3D() != Vector3.zero);
        _movementDirection = Camera.main.transform.rotation * _player.user.GetJoystick3D();
        _movementDirection.y = 0;
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
        //transform.position();
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
