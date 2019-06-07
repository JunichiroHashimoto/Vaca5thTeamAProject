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

        if ( OVRInput.GetDown(OVRInput.Button.One)
           || OVRInput.GetDown(OVRInput.Button.Two)
           || OVRInput.GetDown(OVRInput.Button.Three)
           || OVRInput.GetDown(OVRInput.Button.Four) )
        {
            startSEAudio.Play();

            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        for (;;)
        {
            var color = fadePanelImage.color;
            fadePanelImage.color = new Color(color.r, color.g, color.b, color.a + 0.075f);
            Debug.Log(fadePanelImage.color);

            bgmAudio.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
            if(bgmAudio.volume <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
                yield break;
            }
        }

    }
}
