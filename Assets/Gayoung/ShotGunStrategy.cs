using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gayoung;

namespace Gayoung 
{
    public class ShotGunStregy : AttackStrategy , IReLoadAble
    {
        public ShotGunStregy(object owner) : base(owner)
        {

        }

        public override void Attack()
        {
            if (player == null)
                return;

            //player.WeaponIndex = 0;
            // �ִϸ��̼ǿ��� ���������� ���� ������ ������ �κ��̴�.
            player.animator.SetInteger("WeaponType", 2);

            // ���� ��ü �κ��̴�.(�ִϸ��̼�)
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                base.WeaponSwap(1);
                player.WeaponChange();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                base.WeaponSwap(2);
                player.WeaponChange();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            { 
                base.WeaponSwap(3);
                player.WeaponChange();
            }
          
        }

        public void ReLoad()// ���� �Ѿ��� ������ �ϴ� �κ��̴�.
        {
            player.animator.SetTrigger("Reload");
            player.animator.SetFloat("ReloadType", 0.6f);
        }
    }

}
