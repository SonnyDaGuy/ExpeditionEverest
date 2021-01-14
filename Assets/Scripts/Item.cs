using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Activatable
{
    [SerializeField] protected ItemType _itemType;

    public override void Activate(CharacterController characterController)
    {
        characterController.TryPickupItem(this);
    }

    public ItemType GetItemType()
    {
        return _itemType;
    }

    public virtual void MakeItemVisual(bool isVisual = true)
    {
        foreach(Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = !isVisual;
        }
        GetComponent<Rigidbody>().isKinematic = isVisual;
        gameObject.layer = isVisual ? 0 : 6;
        this.enabled = !isVisual;
    }
}
