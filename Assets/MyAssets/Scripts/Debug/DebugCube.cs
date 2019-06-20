using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DebugCube : MonoBehaviour {

    OVRGrabbable grabbable;
    bool isShowDebug;
    DebugPanel debugPanel;
    Animation anim;
    bool isDebugShowKeyDown;


    // Use this for initialization
    void Start () {
        grabbable = GetComponent<OVRGrabbable>();

        debugPanel = GetComponentInChildren<DebugPanel>();
        anim = debugPanel.GetComponent<Animation>();
        debugPanel.gameObject.SetActive(false);

        isShowDebug = false;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("KeyDown");
            isDebugShowKeyDown = true;
        }
        else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("KeyUp");
            isDebugShowKeyDown = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if( !anim.isPlaying && isDebugShowKeyDown )
        {
            if (isShowDebug)
            {
                Debug.Log("Hide");
                isShowDebug = false;
                anim.Play("DebugPanelHide");

                StartCoroutine( SetActiveWaitAnim(debugPanel.gameObject,false) );
            }
            else
            {
                Debug.Log("Show");
                isShowDebug = true;
                debugPanel.gameObject.SetActive(true);
                anim.Play("DebugPanelShow");
            }

            isDebugShowKeyDown = false;
        }

    }

    IEnumerator SetActiveWaitAnim(GameObject gameObj, bool isActive)
    {
        while(anim.isPlaying)
        {
            yield return null;
        }

        gameObj.SetActive(isActive);
    }
}
