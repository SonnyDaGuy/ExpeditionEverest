using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : ItemDependentActivatable
{
    protected override void ActivateAfterCheck(CharacterController characterController)
    {
        EnableOutline(false, characterController);
        ((Torch)characterController.GetItem()).Light(characterController);
    }
}
