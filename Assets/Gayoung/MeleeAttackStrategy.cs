using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jinho;

namespace Gayoung
{
    public class MeleeAttackStrategy : AttackStrategy
    {
        public MeleeAttackStrategy(object owner) : base(owner)
        {
        }
        public override void Attack()
        {
            // ���� ���� �ִϸ��̼� �����ϱ�


            // ���� ��ü �κ��̴�.(�ִϸ��̼�)
            if (Input.GetKeyDown(KeyCode.Alpha1))
                base.WeaponSwap(0);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                base.WeaponSwap(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                base.WeaponSwap(3);

        }

    }

}