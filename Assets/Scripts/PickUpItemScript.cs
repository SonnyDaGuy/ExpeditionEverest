using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemScript : MonoBehaviour
{
    public bool GetInteractButton;
   public enum PickUpItem { 
        Item1,
        Item2,
        Item3
    }
    public PickUpItem Item;
    // Start is called before the first frame update
    void Start()
    {
        GetInteractButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetInteractButton) 
        {
            switch (Item) 
            {
                case PickUpItem.Item1:
                    Item1Function();
                    break;
                case PickUpItem.Item2:
                    Item2Function();
                    break;
                case PickUpItem.Item3:
                    Item3Function();
                    break;
                default:
                    break;
            }
        }
    }

    void Item1Function() { }

    void Item2Function() { }

    void Item3Function() { }
}
