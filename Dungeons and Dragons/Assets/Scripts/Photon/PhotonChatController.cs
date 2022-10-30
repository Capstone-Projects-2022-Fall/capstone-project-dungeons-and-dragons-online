using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using Photon;
using ExitGames.Client.Photon;
using System;

public class PhotonChatController : MonoBehaviour, IChatClientListener
{
    [SerializeField] private string userName;
    private ChatClient chatClient;
    public static Action<string, string> OnRoomInvite = delegate{};

    private void Awake()
    {
        userName = PlayerPrefs.GetString("USERNAME");
        UIInvitePlayer.OnInvitePlayer += HandleFriendInvite;
    }

    private void OnDestroy(){
        UIInvitePlayer.OnInvitePlayer -= HandleFriendInvite;
    }
    private void Start()
    {
        chatClient = new ChatClient(this);
        ConnectToPhotonChat();
    }

    private void Update()
    {
        chatClient.Service();
    }

    private void ConnectToPhotonChat()  {
        Debug.Log("connecting to photon chat");
        chatClient.AuthValues = new Photon.Chat.AuthenticationValues(userName);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userName));
    }

    public void HandleFriendInvite(string recipient){
        chatClient.SendPrivateMessage(recipient, PhotonNetwork.CurrentRoom.Name);
    }
    /// <summary>
    /// All debug output of the library will be reported through this method. Print it or put it in a
    /// buffer to use it on-screen.
    /// </summary>
    /// <param name="level">DebugLevel (severity) of the message.</param>
    /// <param name="message">Debug text. Print to System.Console or screen.</param>
    public void DebugReturn(DebugLevel level, string message){
       
    }

    /// <summary>
    /// Disconnection happened.
    /// </summary>
    public void OnDisconnected(){
        Debug.Log("You have disconnected from photon chat");
    }

    /// <summary>
    /// Client is connected now.
    /// </summary>
    /// <remarks>
    /// Clients have to be connected before they can send their state, subscribe to channels and send any messages.
    /// </remarks>
    public void OnConnected(){
        Debug.Log("You have connected to photon chat");
    }

    /// <summary>The ChatClient's state changed. Usually, OnConnected and OnDisconnected are the callbacks to react to.</summary>
    /// <param name="state">The new state.</param>
    public void OnChatStateChange(ChatState state){
        
    }

    /// <summary>
    /// Notifies app that client got new messages from server
    /// Number of senders is equal to number of messages in 'messages'. Sender with number '0' corresponds to message with
    /// number '0', sender with number '1' corresponds to message with number '1' and so on
    /// </summary>
    /// <param name="channelName">channel from where messages came</param>
    /// <param name="senders">list of users who sent messages</param>
    /// <param name="messages">list of messages it self</param>
    public void OnGetMessages(string channelName, string[] senders, object[] messages){
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Notifies client about private message
    /// </summary>
    /// <param name="sender">user who sent this message</param>
    /// <param name="message">message it self</param>
    /// <param name="channelName">channelName for private messages (messages you sent yourself get added to a channel per target username)</param>
    public void OnPrivateMessage(string sender, object message, string channelName){
        if(!string.IsNullOrEmpty(message.ToString())){
            //Channel Name format [sender: recipient]
            
            string[] splitNames = channelName.Split(new char[] {':'});
            string senderName = splitNames[0];
            string recipientName = splitNames[1];
            

            if(!sender.Equals(senderName, System.StringComparison.OrdinalIgnoreCase)){
                OnRoomInvite?.Invoke(sender, message.ToString());
                Debug.Log(recipientName +":"+ message);
            }
        }
    }

    /// <summary>
    /// Result of Subscribe operation. Returns subscription result for every requested channel name.
    /// </summary>
    /// <remarks>
    /// If multiple channels sent in Subscribe operation, OnSubscribed may be called several times, each call with part of sent array or with single channel in "channels" parameter. 
    /// Calls order and order of channels in "channels" parameter may differ from order of channels in "channels" parameter of Subscribe operation.
    /// </remarks>
    /// <param name="channels">Array of channel names.</param>
    /// <param name="results">Per channel result if subscribed.</param>
    public void OnSubscribed(string[] channels, bool[] results){
        
    }

    /// <summary>
    /// Result of Unsubscribe operation. Returns for channel name if the channel is now unsubscribed.
    /// </summary>
    /// If multiple channels sent in Unsubscribe operation, OnUnsubscribed may be called several times, each call with part of sent array or with single channel in "channels" parameter. 
    /// Calls order and order of channels in "channels" parameter may differ from order of channels in "channels" parameter of Unsubscribe operation.
    /// <param name="channels">Array of channel names that are no longer subscribed.</param>
    public void OnUnsubscribed(string[] channels){
       
    }

    /// <summary>
    /// New status of another user (you get updates for users set in your friends list).
    /// </summary>
    /// <param name="user">Name of the user.</param>
    /// <param name="status">New status of that user.</param>
    /// <param name="gotMessage">True if the status contains a message you should cache locally. False: This status update does not include a message (keep any you have).</param>
    /// <param name="message">Message that user set.</param>
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message){
       
    }

    /// <summary>
    /// A user has subscribed to a public chat channel
    /// </summary>
    /// <param name="channel">Name of the chat channel</param>
    /// <param name="user">UserId of the user who subscribed</param>
    public void OnUserSubscribed(string channel, string user){
       
    }

    /// <summary>
    /// A user has unsubscribed from a public chat channel
    /// </summary>
    /// <param name="channel">Name of the chat channel</param>
    /// <param name="user">UserId of the user who unsubscribed</param>
    public void OnUserUnsubscribed(string channel, string user){
       
    }


}
