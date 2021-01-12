using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Item
{
    public void Light()
    {
        GetComponent<ParticleSystem>().Play();
        _itemType = ItemType.torchLit;
    }
}
