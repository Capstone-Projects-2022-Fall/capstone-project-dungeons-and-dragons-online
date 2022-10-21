using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using Photon.Realtime;

public class MenuController : MonoBehaviourPunCallbacks
{
    //Idk what this is so dont touch it
    [SerializeField] private AppSettings VersionName ;

    //The menus for connecting
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    //Input boxes for connecting
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    //Just the start button
    [SerializeField] private GameObject StartButton;

    public static Action GetPhotonFriends = delegate{};

    /// <summary>
    /// Connects to photon network when the main menu opens
    /// </summary>
    private void Awake(){
        //Connects to the photon network
        //PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// Changes the players username to the one passed by the user
    /// </summary>
    private void Start(){
        //Displays username menu
        UsernameMenu.SetActive(true);
    }

    /// <summary>
    /// When the user joins the lobby, send a message to the console confirming connection
    /// </summary>
    public override void OnConnectedToMaster(){
        Debug.Log("Connected");
        //Joins lobby
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //Print to log
    }

    /// <summary>
    /// Changes the players username to the one passed by the user
    /// </summary>
    public void ChangeUsernameInput(){
        //Username mus be at least 3 characters in length
        if(UsernameInput.text.Length>=3){
            StartButton.SetActive(true);
        }
        else{  //Otherwise the start button will not appear
            StartButton.SetActive(false);
        }
    }

    /// <summary>
    /// Takes the text from the username input box and send the name to the unity server
    /// </summary>
    public void setUsername(){
        //Turns of username menu
        //UsernameMenu.SetActive(false);
        //Sets player username
    
        
        PhotonNetwork.NickName = UsernameInput.text;
        PlayerPrefs.SetString("USERNAME", UsernameInput.text);

        UIInvite.OnRoomInviteAccept += HandleRoomInviteAccept;

        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=8;
        PhotonNetwork.JoinOrCreateRoom("Main", roomOptions, TypedLobby.Default);
        
        
    }

    public void OnDestroy(){
        UIInvite.OnRoomInviteAccept -= HandleRoomInviteAccept;
    }

    /// <summary>
    /// Creates a photon lobby from the user passed name
    /// </summary>
    public void CreateGame(){
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions(){MaxPlayers = 8}, null);
    }

    /// <summary>
    /// Joins a photon lobby from the user passed name or makes a new one if one with that name does not exist
    /// </summary>
    public void JoinGame(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=8;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    /// <summary>
    /// Once player joins room, launch the game
    /// </summary>
    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("MainGame");
    }

    private void HandleRoomInviteAccept(string roomName){
        PlayerPrefs.SetString("PHOTONROOM",roomName);
        if(PhotonNetwork.InRoom){
            PhotonNetwork.LeaveRoom();
        }
        else{
            if(PhotonNetwork.InLobby){
                JoinPlayerRoom();
            }
        }
    }

    private void JoinPlayerRoom(){
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        PlayerPrefs.SetString("PHOTONROOM", roomName);
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedLobby()
    {
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        if(!string.IsNullOrEmpty(roomName)){
            JoinPlayerRoom();
        }
        else{
            //PhotonNetwork.CreateRoom(PhotonNetwork.LocalPlayer.UserId);
        }
    }


}
