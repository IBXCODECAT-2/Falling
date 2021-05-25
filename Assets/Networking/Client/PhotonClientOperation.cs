using Photon;
using Photon.Chat;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonClientOperation : ThisClientCallback
{
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        PhotonNetwork.JoinRandomRoom();
    }
}
