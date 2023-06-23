//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Cube02 : MonoBehaviour
//{
//    BoxCollider col;
//    public Manager manager;
//    public int number;
//    public int numberCell;

//    // Start is called before the first frame update
//    void Start()
//    {


//        col = GetComponent<BoxCollider>();
//    }


//    void OnMouseDown()
//    {


//        if (!manager.isWin)
//        {
//            //col.enabled = false;
//            RaycastHit hit;

//            if (!Physics.Linecast(transform.position, transform.position + transform.right, out hit))
//            {
//                transform.position = new Vector3(transform.position.x + (float)0.75, transform.position.y, transform.position.z);
//            }
//            else if (!Physics.Linecast(transform.position, transform.position + -transform.right, out hit))
//            {
//                transform.position = new Vector3(transform.position.x - (float)0.75, transform.position.y, transform.position.z);
//            }
//            else if (!Physics.Linecast(transform.position, transform.position + transform.up, out hit))
//            {
//                transform.position = new Vector3(transform.position.x, transform.position.y + (float)0.75, transform.position.z);
//            }
//            else if (!Physics.Linecast(transform.position, transform.position + -transform.up, out hit))
//            {
//                transform.position = new Vector3(transform.position.x, transform.position.y - (float)0.75, transform.position.z);
//            }
//            col.enabled = true;

//        }

//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "trigger")
//        {
//            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
//            manager.win();
//        }
//    }

//}
