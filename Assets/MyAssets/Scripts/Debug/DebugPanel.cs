using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

    [SerializeField]
    Text infoText;

	void Start () {
		
	}
	
	void Update () {

        float fps = OVRPlugin.GetAppFramerate();
        infoText.text = System.String.Format("FPS: {0:F2}", fps);

    }
}
