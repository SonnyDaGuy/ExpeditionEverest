using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : ItemDependentActivatable
{
    [SerializeField] private GameObject _fire;
    protected override void ActivateAfterCheck(CharacterController characterController)
    {
        EnableOutline(false, characterController);
        _fire.SetActive(true);
        characterController.UseItem();
    }
}
