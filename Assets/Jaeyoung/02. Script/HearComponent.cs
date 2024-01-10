using Hojun;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Jaeyoung
{
    // 231211 hojun made
    // ����� ã�Ҵٴ� Ȯ���� �� �ִ� ���� ������ ���� �� ��.

    public class HearComponent : MonoBehaviourPunCallbacks , IHearAble
    {
        // �߰�, �ν� ���� (�뷱�� ������ �� ����)
        const float ChaseValue = 2.0f;
        const float DetectiveValue = 1.0f;

        [SerializeField]
        float resultDistance;
        [SerializeField]
        GameObject soundOwner;
        [SerializeField]
        Vector3 soundArea;


        public GameObject SoundOwner 
        {
            get 
            {
                return soundOwner;
            }
            set
            {
                soundOwner = value;
                if(value != null)
                    soundArea = value.transform.position;
            }
        }
        
        public Vector3 SoundArea 
        {
            get { return soundArea; }
        }

        public float ResultDistance 
        {
            get
            {
                return resultDistance;
            }    
        }


        [PunRPC]
        public void Hear(GameObject soundOwner)
        {
            float soundSize = soundOwner.GetComponent<SoundComponent>().soundAreaSize;
            resultDistance = (soundSize - Vector3.Distance(transform.position, soundOwner.transform.position));
            SoundOwner = soundOwner;
        }

        public void InitTarget()
        {
            resultDistance = 0.0f;
            soundOwner = null;
            soundArea = Vector3.zero;
        }

    }
}