using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState : MonoBehaviour {

    
    public bool isFlowerGrabbing
    {
        get
        {
            return ovrGrabber.grabbedObject != null && ovrGrabber.grabbedObject.CompareTag(CommonDefine.TagFlower);
        }
    }

    OVRGrabber ovrGrabber;

    void Start()
    {
        ovrGrabber = GetComponent<OVRGrabber>();
    }

}
