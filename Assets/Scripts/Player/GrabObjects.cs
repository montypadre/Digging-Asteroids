using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    //[SerializeField]
    //private Transform rayPoint;
    //[SerializeField]
    //private float rayDistance;

    //private GameObject grabbedObject;
    //private int layerIndex;
    //private bool isGrabbing = false;

    //void Start()
    //{
    //    layerIndex = LayerMask.NameToLayer("Objects");
    //}

    public void GrabObject(GameObject grabbedObject)
    {
        // isGrabbing = true;
        // RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        //Debug.Log("grabbed");
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.position = grabPoint.position;
        grabbedObject.transform.SetParent(transform);

  //      if (Input.GetMouseButtonUp(0))
		//{
  //          grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
  //          grabbedObject.transform.SetParent(null);
  //          grabbedObject = null;
  //      }

  //      if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
		//{
  //          // grab object
		//	if (Input.GetMouseButton(0) && grabbedObject == null)
		//	{
  //              Debug.Log("Grabbed");
  //              grabbedObject = hitInfo.collider.gameObject;
  //              grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
  //              grabbedObject.transform.position = grabPoint.position;
  //              grabbedObject.transform.SetParent(transform);
		//	}
  //          // release object
  //          if (Input.GetMouseButton(0))
  //          {
  //              Debug.Log("Released");
  //              grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
  //              grabbedObject.transform.SetParent(null);
  //              grabbedObject = null;
  //          }
		//}

        //Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }

    public void ReleaseObject(GameObject releasedObject)
	{
        //Debug.Log("released");
        releasedObject.GetComponent<Rigidbody>().isKinematic = false;
        releasedObject.transform.SetParent(null);
        releasedObject = null;
    }
}
