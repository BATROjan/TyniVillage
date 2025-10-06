using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class RoomListItem : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public RoomInfo Info;
        public void SetUp(RoomInfo roomInfo)
        {
            Info = roomInfo;
            _text.text = Info.Name;
        }

        public void OnCLick()
        {
            Launcher.instance.JoinRoom(Info);
        }
    }
}