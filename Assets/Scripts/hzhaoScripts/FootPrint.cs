using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    private bool leftPrint;
    public Vector3 offset;
    public GameObject leftFoot;
    public GameObject rightFoot;
    Vector3 location;
    Vector3 direction;
    Vector3 rayOffSet;
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        location = GetComponent<Transform>().position;
        direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*currentVelocity = GetComponent<Rigidbody>().velocity;
        if (currentVelocity.magnitude != 0)
        {
            CreateFootPrint();
        }*/
        Debug.DrawRay(location, direction * 5, Color.red);
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateFootPrint();
        }
    }

    public void CreateFootPrint() {
        RaycastHit hit;
        //to be change varible
       
        //player direction;
        Quaternion rotation = Quaternion.identity;
        direction = direction.normalized;
        if(Physics.Raycast(location, direction, out hit))
        {
            
            Vector3 printLocation = hit.point;
            if (leftPrint)
            {
                printLocation = printLocation + offset;
                Instantiate(leftFoot, printLocation, rotation);
                leftPrint = false;
            }
            else if (!leftPrint)
            {
                printLocation = printLocation - offset;
                Instantiate(rightFoot, printLocation, rotation);
                leftPrint = true;
            }
            
        }
        
    }
}
