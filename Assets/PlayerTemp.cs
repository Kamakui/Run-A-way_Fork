using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hojun;


public class PlayerTemp : MonoBehaviour, IHitAble
{
    public CharacterData Data => throw new System.NotImplementedException();

    public void Hit(float damage, IAttackAble attacker)
    {
        Debug.Log("���ݴ���");
    }

    public void Hit(float damage)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
