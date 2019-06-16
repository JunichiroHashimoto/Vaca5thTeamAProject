using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

    [SerializeField]
    Text infoText;
    [SerializeField]
    Button GoFreeButton;
    [SerializeField]
    Button GoGuideButton;

    void Start () {
        GoGuideButton.onClick.AddListener(GotoGuidePart);
        GoFreeButton.onClick.AddListener(GotoFreePart);
    }

    void Update () {

        float fps = OVRPlugin.GetAppFramerate();
        infoText.text = System.String.Format("FPS: {0:F2}", fps);

    }

    public void GotoGuidePart()
    {
        Debug.Log("Goto Guide Part");
        AppManager.instance.ChangeGuidePart();
    }

    public void GotoFreePart()
    {
        Debug.Log("Goto Free Part");
        AppManager.instance.ChangePartFree();
    }

}
