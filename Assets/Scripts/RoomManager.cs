using System;
using System.IO;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class RoomManager : MonoBehaviourPunCallbacks
    {
        public static RoomManager instance;

        private void Start()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        override public void OnEnable()
        {
            base.OnEnable();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 1)
            {
                PhotonNetwork.Instantiate(
                    Path.Combine("PlayerManager"), 
                    Vector3.zero, Quaternion.identity);
            }
        }

        override public void OnDisable()
        {
            
        }
    }
}