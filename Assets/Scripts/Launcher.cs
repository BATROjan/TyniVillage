using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private TextMeshProUGUI roomNameText;
    [SerializeField] private Transform _roomlist;
    [SerializeField] private GameObject roomButtonPrefabs;
    [SerializeField] private Transform playerlist;
    [SerializeField] private GameObject playerNamePrefab;
    [SerializeField] private GameObject startGameButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        Debug.Log("Connection to Master Service");
        PhotonNetwork.ConnectUsingSettings();
        MenuManager.instance.OpenMenu("Load");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Service");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby Connection");
        MenuManager.instance.OpenMenu("Title");
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(inputField.text);
        MenuManager.instance.OpenMenu("Load");
    }

    public override void OnJoinedRoom()
    {
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.instance.OpenMenu("Room");
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < playerlist.childCount; i++)
        {
            Destroy(playerlist.GetChild(i).gameObject);
        }
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerNamePrefab, playerlist).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
    }

    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("Load");
    }

    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenu("Title");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Error " + message;
        MenuManager.instance.OpenMenu("Error");
        
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.instance.OpenMenu("Load");

    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < _roomlist.childCount; i++)
        {
            Destroy(_roomlist.GetChild(i).gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomButtonPrefabs, _roomlist).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player player)
    {
        Instantiate(playerNamePrefab, playerlist).GetComponent<PlayerListItem>().SetUp(player);
    }
}
