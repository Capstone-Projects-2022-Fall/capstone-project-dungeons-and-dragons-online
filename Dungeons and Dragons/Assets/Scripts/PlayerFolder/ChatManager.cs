using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using Photon.Pun;
using Photon;
using TMPro;

public class ChatManager : MonoBehaviour, Photon.Pun.IPunObservable
{
    public PhotonView photonView;
    public TextMeshProUGUI chatContent;
    public TMP_InputField chatInput;
    private List<string> messages = new List<string>();
    private float delay = 0f;
    private int maxMessages = 10;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        // chatInput = GameObject.Find("ChatInputField").GetComponent<TMP_InputField>();
    }

    [PunRPC]
    private void Update()
    {
        if(PhotonNetwork.InRoom)
        {
            chatContent.maxVisibleLines = maxMessages;
            if(messages.Count>maxMessages)
            {
                messages.RemoveAt(0);
            }
            if(delay < Time.time)
            {
                BuildChat();
                delay = Time.time + 0.25f;
            }
        }
        else if(messages.Count>0)
        {
            messages.Clear();
            chatContent.text = "";
        }
    }

    [PunRPC]
    void RPC_AddNewMessage(string message)
    {
        messages.Add(message);
    }

    [PunRPC]
    public void SendMessage(string message)
    {
        string newMessage = PhotonNetwork.NickName + ": " + message;
        photonView.RPC("RPC_AddNewMessage", RpcTarget.AllBuffered, newMessage);
    }

    public void SubmitMessage()
    {
        string blankCheck = chatInput.text;
        blankCheck = Regex.Replace(blankCheck, @"\s", "");
        if(blankCheck == "")
        {
            chatInput.ActivateInputField();
            chatInput.text = "";
            return;
        }
        SendMessage(chatInput.text);
        chatInput.ActivateInputField();
        chatInput.text = "";
    }

    public void BuildChat()
    {
        string newContents = "";
        foreach(string s in messages)
        {
            newContents += s + "\n";
        }
        chatContent.text = newContents;
    }

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
    {
    }


}