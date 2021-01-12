using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    private bool leftPrint;
    public Vector3 offset;
    public GameObject leftFoot;
    public GameObject rightFoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //do createFootPrint if player moving;
    }

    public void CreateFootPrint(GameObject prefab) {
        RaycastHit hit;
        //to be change varible
        Vector3 location = new Vector3(0, 0, 0);
        Vector3 direction = new Vector3(0, 0, 0);
        //player direction;
        Quaternion rotation = Quaternion.identity;
        direction = direction.normalized;
        if(Physics.Raycast(location, direction, out hit))
        {
            Vector3 printLocation = hit.point;
            if (leftPrint)
            {
                printLocation = printLocation + offset;
                Instantiate(prefab, printLocation, rotation);
                leftPrint = false;
            }
            else if (!leftPrint)
            {
                printLocation = printLocation - offset;
                Instantiate(prefab, printLocation, rotation);
                leftPrint = true;
            }
            
        }
        
    }
}
