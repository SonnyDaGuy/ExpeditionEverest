using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ItemDependentActivatable
{
    protected override void ActivateAfterCheck(CharacterController characterController)
    {
        characterController.UseItem();
        Destroy(gameObject);
    }
}
