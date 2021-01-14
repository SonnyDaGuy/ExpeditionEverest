using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDependentActivatable : Activatable
{
    [SerializeField] private ItemType _itemRequiredForActivation;

    public override void EnableOutline(bool enable, CharacterController characterController)
    {
        if (characterController.GetItemType() == _itemRequiredForActivation)
        {
            base.EnableOutline(enable, characterController);
        }
    }

    public override void Activate(CharacterController characterController)
    {
        if(characterController.GetItemType() == _itemRequiredForActivation)
        {
            ActivateAfterCheck(characterController);
        }
    }

    protected abstract void ActivateAfterCheck(CharacterController characterController);
}
