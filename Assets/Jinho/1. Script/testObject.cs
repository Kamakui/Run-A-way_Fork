using Hojun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testObject : MonoBehaviour, Hojun.IHitAble, IAttackAble
{
    public CharacterData Data => throw new System.NotImplementedException();

    public GameObject GetAttacker()
    {
        return gameObject;
    }

    public float GetDamage()
    {
        return 10;
    }

    public void Hit(float damage, IAttackAble attacker)
    {
        Debug.Log(attacker.GetAttacker().name + "���� �¾���");
    }

    public void Hit(float damage)
    {
        
    }


}
