using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _photonView;
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
       var item = PhotonNetwork.Instantiate(Path.Combine("PlayerController"), Vector3.zero, Quaternion.identity);
        item.transform.position = new Vector2(-38, 5);
    }
}
