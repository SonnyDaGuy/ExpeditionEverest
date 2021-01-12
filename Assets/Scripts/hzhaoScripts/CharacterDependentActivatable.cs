using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDependentActivatable : Activatable
{
    public enum BehaviourType { 
        digging
    }

    [SerializeField] private BehaviourType behaviourForActivate;
    public GameObject prefab1;

    public override void Activate(CharacterController characterController) 
    {
        if (characterController.GetCharacterType() == CharacterType.Dog) {
            if (behaviourForActivate == BehaviourType.digging) {             
                SpawnItem(prefab1, getTileLocation());                
            }
        }
    }

    public void SpawnItem(GameObject prefab, Vector3 location) {
        Instantiate(prefab, location, Quaternion.identity);
    }

    //these function are substitute
    public Vector3 getTileLocation() {
        Vector3 location = new Vector3(0, 0, 0);
        return location;
    }

    public ItemType getItemType() {
        ItemType item = ItemType.pickaxe;
        return item;
    }
}
