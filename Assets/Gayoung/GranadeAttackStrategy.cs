using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jinho;

namespace Gayoung 
{
    public class GranadeAttackStrategy : AttackStrategy 
    {
        public GranadeAttackStrategy(object owner) : base(owner)
        {
        }
        public override void Attack()
        {
            if (player == null)
                return;

           // player.WeaponIndex = 3;
            // ���� ���� �ִϸ��̼� �����ϱ�
            player.animator.SetInteger("WeaponType", 5);

            // ���� ��ü �κ��̴�.(�ִϸ��̼�)
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                base.WeaponSwap(0);
                player.WeaponChange();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                base.WeaponSwap(1);
                player.WeaponChange();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                base.WeaponSwap(2);
                player.WeaponChange();
            }

        }

    }



}
