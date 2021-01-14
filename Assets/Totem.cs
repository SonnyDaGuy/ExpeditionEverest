using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : CharacterDependentActivatable
{
    private Animator _animator;

    void Awake()
    {
        _animator.GetComponent<Animator>();
    }

    protected override void ActivateAfterCheck(CharacterController characterController)
    {
        _animator.SetTrigger("Fall");
        //characterController.transform.position - ;
    }
}
