using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using System.Threading;

public class MessageManager : MonoBehaviour {

    [SerializeField]
    Image messagePanel;
    [SerializeField]
    TextMeshProUGUI messageText;
    [SerializeField]
    Canvas messageCanvas;

    public static MessageManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start () {
        messageText.text = "";
        messagePanel.gameObject.SetActive(false);

        // メッセージパネル出現以外のアニメはしないのでAnimatorをOFF
        AppManager.DelayInvoke(() =>
        {
            messagePanel.GetComponent<Animator>().enabled = false;
        }, 5f);
    }
	
	void Update () {
		
	}

    public void SetBackColor(Color color)
    {
        messagePanel.color = color;
    }

    public void DisplayMessage(string message)
    {
        messageText.text = message;
        messagePanel.gameObject.SetActive(true);
    }

    public async Task HideMessage(float delay = 0f)
    {
        if (delay != 0)
        {
            await Task.Delay((int)(delay*1000));
        }
        messagePanel.gameObject.SetActive(false);

    }

    public async Task ChangeMessage(string message, float delay = 0f)
    {
        if (delay != 0)
        {
            await Task.Delay((int)(delay * 1000));
        }
        messageText.text = message;
    }

}
