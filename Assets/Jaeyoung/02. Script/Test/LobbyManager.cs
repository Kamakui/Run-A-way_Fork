using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject missionManager;
    [SerializeField] GameObject characterPrafab;
    [SerializeField] TextMeshProUGUI countText;

    private void Start()
    {
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "TEST";
    }

    private void Update()
    {
        if (PhotonNetwork.IsConnected == false)
            return;

        countText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            missionManager.SetActive(true);
        }
    }


    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("���η� ����");
            PhotonNetwork.JoinRandomRoom();
        }
        else
            PhotonNetwork.ConnectUsingSettings();

    }

    public void LeftRoom()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    //MonoBehaviourPunCallbacks�� MonoBehaviour�̹Ƿ� (��Ӱ���)
    //����Ƽ���� �����ϴ� �̺�Ʈ �Լ� OnEnable�� OnDisable�� ����Ͽ���, �����صξ�����,
    //���� MonoBehaviourPunCallbacks�� ��ӹ޾Ұ� �ش� �̺�Ʈ �Լ��� ����Ϸ��� �� override�Ұ�.
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() ȣ�� ��. ���� ��");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected() ȣ�� ��. ������ ������");
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("���̾����, Ȥ�� �� �� �������");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("���� �濡 ���Խ��ϴ�.");
        GameObject obj = PhotonNetwork.Instantiate(characterPrafab.name, spawnPoint.transform.position, transform.rotation);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "�濡 ���Խ��ϴ�.");

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + "�濡�� �������ϴ�.");
    }
}
