using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    AudioSource startSEAudio;
    [SerializeField]
    AudioSource bgmAudio;
    [SerializeField]
    Image fadePanelImage;
    
    enum State
    {
        None,
        PushButtonWait,
        LoadNext,
    }

    State state = State.None;

    void Start()
    {
        state = State.PushButtonWait;
    }

    void Update () {

        if(state != State.PushButtonWait)
        {
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.One)
           || OVRInput.GetDown(OVRInput.Button.Two)
           || OVRInput.GetDown(OVRInput.Button.Three)
           || OVRInput.GetDown(OVRInput.Button.Four)
           || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
           || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)
        )
        {
            startSEAudio.Play();

            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        for (;;)
        {
            var color = fadePanelImage.color;
            fadePanelImage.color = new Color(color.r, color.g, color.b, color.a + 0.05f);
            bgmAudio.volume -= 0.025f;
            if(bgmAudio.volume <= 0)
            {
                yield break;
            }
            yield return new WaitForSeconds(0.05f);
        }

    }
}
