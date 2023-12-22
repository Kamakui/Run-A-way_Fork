using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Jaeyoung
{
    public class Breakthrough : Mission
    {
        public int groupCount;
        [SerializeField] private int curCount;
        public int CurCount
        {
            get { return curCount; }
            set
            { 
                curCount = value;
                UIManager.instance.missionUI.CompleteUpdate((float)curCount / (float)groupCount);
                // ������ �� �̼� ���� UI����
            }
        }

        private void Start()
        {
            // ����ִ� �ο����� groupCount�� �־������
            groupCount = PhotonNetwork.CurrentRoom.PlayerCount;
            UIManager.instance.missionUI.CompleteUpdate();
        }

        public override bool Condition()
        {
            // �÷��̾ Ư�� ��ġ�� �ο��� ��ŭ 
            return curCount == groupCount;
        }

        public override void Play()
        {
            base.Play();
        }
    }
}