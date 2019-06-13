using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLogController : MonoBehaviour {

    [SerializeField]
    Text logText;

    bool pushing = false;
    Coroutine checkCoroutine;

    void Update () {
        if (pushing)
        {
            if (OVRInput.GetUp(OVRInput.Button.One)
              || OVRInput.GetUp(OVRInput.Button.One)
              || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)
              || OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                pushing = false;
                if (checkCoroutine != null)
                {
                    pushing = false;
                    StopCoroutine(checkCoroutine);

                }
            }
        }
        else
        {

            if (!pushing && OVRInput.Get(OVRInput.Button.One)
              && OVRInput.Get(OVRInput.Button.Two)
              && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)
              && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {

                pushing = true;
                checkCoroutine = StartCoroutine(CheckDebugSwitch());
            }
        }

    }

    IEnumerator CheckDebugSwitch()
    {
        yield return new WaitForSeconds(3f);

        logText.enabled = !logText.enabled;

    }
}
