using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterDependentActivatable : Activatable
{
    [SerializeField] private CharacterType _characterRequiredForActivation;

    public override void EnableOutline(bool enable, CharacterController characterController)
    {
        if (characterController.GetCharacterType() == _characterRequiredForActivation)
        {
            base.EnableOutline(enable, characterController);
        }
    }

    public override void Activate(CharacterController characterController)
    {
        if (characterController.GetCharacterType() == _characterRequiredForActivation)
        {
            ActivateAfterCheck(characterController);
        }
    }

    protected abstract void ActivateAfterCheck(CharacterController characterController);
}
