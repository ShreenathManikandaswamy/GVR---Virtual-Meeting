﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMan : Photon.MonoBehaviour
{

    public const string version = "1.0";
    public Transform[] spawnPoints;
    //public Transform[] spawnPointscam;

    public GameObject avatarprefab;
    //public GameObject[] camera;
    // Use this for initialization
    void Start()
    {

        PhotonNetwork.ConnectUsingSettings(version);
        var temp = PhotonVoiceNetwork.Client;
    }

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        //GameObject c = PhotonNetwork.Instantiate(camera.name, spawnPointscam[PhotonNetwork.otherPlayers.Length].position, Quaternion.identity, 0);
        //GameObject o = PhotonNetwork.Instantiate(avatarprefab.name, spawnPoints[PhotonNetwork.otherPlayers.Length].position, Quaternion.identity, 0);
        //if(photonView.isMine)
        //o.GetComponent<CopyScript>().enabled = true;

        //isConnected = false;
        //isInRoom = true;
        spawnPlayer();


    }
    public void spawnPlayer()
    {
        //isInRoom = false;
        Debug.Log("Spawning Player");
        GameObject o = PhotonNetwork.Instantiate(avatarprefab.name, spawnPoints[PhotonNetwork.otherPlayers.Length].position, Quaternion.identity, 0);
        //avatarprefab[PhotonNetwork.otherPlayers.Length] = o;
        Debug.Log("Spaw" + PhotonNetwork.otherPlayers.Length);
        o.GetComponent<CopyScript>().enabled = true;
        o.GetComponent<CopyScript>().camera.SetActive(true);
        //o.GetComponent<GyroController>().enabled = true;


    }

}
