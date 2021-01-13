using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemScript : MonoBehaviour
{
    Transform objTrans;
    MeshRenderer objMesh;
    Vector3 objSize;
    float root3Over2;
    //use for debug
    Vector3 direction1;
    Vector3 direction2;
    Vector3 direction3;
    Vector3 direction4;
    Vector3 direction5;
    Vector3 direction6;
    //end here
    Vector3 direction;
    public enum rotationTotem { 
        angle1,
        angle2,
        angle3,
        angle4,
        angle5,
        angle6
    }

    [SerializeField] private rotationTotem thisAngle;

    // Start is called before the first frame update
    void Start()
    {
        objTrans = GetComponent<Transform>();
        objMesh = GetComponent<MeshRenderer>();
        Vector3 direction = new Vector3(0, 0, 1);
        root3Over2 = Mathf.Sqrt(3) / 2;
        direction1 = new Vector3(0, 0, 1);
        direction2 = new Vector3(root3Over2, 0, 0.5f);
        direction3 = new Vector3(-root3Over2, 0, 0.5f);
        direction4 = new Vector3(0, 0, -1);
        direction5 = new Vector3(-root3Over2, 0, -0.5f);
        direction6 = new Vector3(root3Over2, 0, -0.5f);
        objSize = objMesh.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(objTrans.position, direction1*5, Color.white);
        Debug.DrawRay(objTrans.position, direction2*5, Color.black);
        Debug.DrawRay(objTrans.position, direction3*5, Color.green);
        Debug.DrawRay(objTrans.position, direction4*5, Color.yellow);
        Debug.DrawRay(objTrans.position, direction5*5, Color.gray);
        Debug.DrawRay(objTrans.position, direction6*5, Color.blue);
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeAngle();
        }
       
    }

    public void changeAngle() {
        
        switch (thisAngle) {
            case rotationTotem.angle1:
                direction = new Vector3(0, 0, 1);
                objTrans.rotation = Quaternion.Euler(90, 0, 0);
                break;
            case rotationTotem.angle2:
                direction = new Vector3(root3Over2, 0, 0.5f);
                objTrans.rotation = Quaternion.Euler(90, 60, 0);
                break;
            case rotationTotem.angle3:
                direction = new Vector3(-root3Over2, 0, 0.5f);
                objTrans.rotation = Quaternion.Euler(90, 120, 0);
                break;
            case rotationTotem.angle4:
                direction = new Vector3(0, 0, -1);
                objTrans.rotation = Quaternion.Euler(90, 180, 0);
                break;
            case rotationTotem.angle5:
                direction = new Vector3(-root3Over2, 0, -0.5f);
                objTrans.rotation = Quaternion.Euler(90, 240, 0);
                break;
            case rotationTotem.angle6:
                direction = new Vector3(root3Over2, 0, -0.5f);
                objTrans.rotation = Quaternion.Euler(90, 300, 0);
                break;
            default:
                break;
        }
        Debug.Log(objSize.y);
        objTrans.transform.position = objTrans.transform.position + direction *objSize.y/2 + Vector3.down*(objSize.y/2-objSize.z/2);
    }

}
