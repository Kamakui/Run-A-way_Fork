using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jinho;

namespace Gayoung 
{
    public class GranadeAttackStrategy : AttackStrategy , IReLoadAble
    {
        public GranadeAttackStrategy(object owner) : base(owner)
        {
        }
        public override void Attack()
        {
            // ���� ���� �ִϸ��̼� �����ϱ�


            // ���� ��ü �κ��̴�.(�ִϸ��̼�)
            if (Input.GetKeyDown(KeyCode.Alpha1))
                base.WeaponSwap(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                base.WeaponSwap(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                base.WeaponSwap(2);

        }
        public void ReLoad()
        {
            //����ź �ִϸ��̼��� ã�Ƽ� ���� ��������!
            throw new System.NotImplementedException();
        }
    }



}
