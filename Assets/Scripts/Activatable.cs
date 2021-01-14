using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour
{
    [SerializeField] protected GameObject _outline;

    public virtual void EnableOutline(bool enable, CharacterController characterController)
    {
        _outline.SetActive(enable);
    }

    public abstract void Activate(CharacterController characterController);
}
