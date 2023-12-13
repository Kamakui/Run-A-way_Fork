using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour, Yeseul.IInteractive
{
    public void Start()
    {
        ((Mission)MissionManager.instance.curMission).clearEvent.AddListener(() => { this.gameObject.SetActive(false); });
    }

    public void Interaction(GameObject interactivePlayer)
    {
        ((Search)MissionManager.instance.curMission).CurCount++;
        gameObject.SetActive(false);
    }

    // ��ȣ�ۿ� �׽�Ʈ�ϰ� ��������
    private void OnTriggerEnter(Collider other)
    {
        Interaction(other.gameObject);
    }
}
