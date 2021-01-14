using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Item
{
    [SerializeField] private GameObject _fire, _pointLightInFire;

    public override void MakeItemVisual(bool isVisual = true)
    {
        base.MakeItemVisual(isVisual);
        _pointLightInFire.SetActive(!isVisual);
    }

    public void Light(CharacterController characterController)
    {
        _fire.SetActive(true);
        _itemType = ItemType.torchLit;
        characterController.LightUpPlayer();
    }
}
