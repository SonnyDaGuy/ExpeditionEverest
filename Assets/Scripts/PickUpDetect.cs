using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetect : MonoBehaviour
{
    PickUpItemScript ParentScript;

    // Start is called before the first frame update
    void Start()
    {
        ParentScript = GetComponentInParent<PickUpItemScript>();
    }

    //detect object entering sphere collider
    private void OnTriggerEnter(Collider other)
    {
        bool Pressed = false;

        //check player input here

        if (Pressed) {
            //posess parent to player
            ParentScript.PossesPlayer();
        }
    }
}
