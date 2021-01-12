using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : Activatable
{
    public override void Activate(CharacterController characterController)
    {
        if(characterController.GetItemType() == ItemType.torchLit)
        {
            LightFire();
        }
    }

    private void LightFire()
    {

        // implement

        Debug.Log("LEVEL FINISHED");
    }
}
