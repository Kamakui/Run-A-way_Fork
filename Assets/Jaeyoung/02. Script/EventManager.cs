using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaeyoung
{
    public interface IMissionable
    {
        public void Update();
    }

    // �ߺ� ���� �ȵǰ� ����ó�� �ʿ�.

    public class DefenseMission : IMissionable
    {
        public void Update()
        {
            Debug.Log("���潺");
        }
    }

    public class SearchMission : IMissionable
    {
        public void Update()
        {
            Debug.Log("Ž��");
        }
    }

    public class BreakthroughMission : IMissionable
    {
        public void Update()
        {
            Debug.Log("����");
        }
    }

    public enum MissionType
    {
        Defense,
        Search,
        Breakthrough
    }

    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;
        public Dictionary<MissionType, IMissionable> missionDic;
        IMissionable curMission;
        IMissionable CurMission
        { 
            get { return curMission; }
            set 
            {
                curMission = value;

                this.gameObject.SetActive(CurMission == null ? false : true);                
            }
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            missionDic = new Dictionary<MissionType, IMissionable>();
            missionDic.Add(MissionType.Defense, new DefenseMission());
            missionDic.Add(MissionType.Search, new SearchMission());
            missionDic.Add(MissionType.Breakthrough, new BreakthroughMission());
            CurMission = null;
        }

        private void Update()
        {
            CurMission?.Update();
        }

        public void TakeMission(MissionType type)
        {
            CurMission = missionDic[type];
        }

        public void MissionOver()
        {
            CurMission = null;
        }
    }
}