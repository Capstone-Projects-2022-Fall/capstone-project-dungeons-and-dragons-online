using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField] private GameObject Username;
    [SerializeField] private InputField JoinRoomInput;
    [SerializeField] private InputField CreatRoomInput;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("PartySystem");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreatRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinRoomInput.text,roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("BattleMap");
    }
    /*
    public void BackTwoMain()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }*/
}
