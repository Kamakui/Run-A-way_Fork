using Hojun;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStrategy : IMoveStrategy
{


    public GameObject Owner => owner.gameObject;
    
    Zombie owner;
    

    public WalkStrategy(Zombie owner)
    {
        this.owner = owner;
    }


    public void Move(GameObject target)
    {

        //TODO_LIST navimeshAgent ����ؼ� target�� ��ġ�� �� �� �ȴ� �Ŵϱ� �ӵ�  *0.7 ���� �ϸ� ���� �� 
        owner.transform.Translate( owner.transform.forward * owner.Data.Speed);
        
    }



}
