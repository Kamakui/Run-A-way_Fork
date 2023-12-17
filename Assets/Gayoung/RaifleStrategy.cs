using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gayoung;
using static UnityEngine.UI.GridLayoutGroup;

namespace Gayoung 
{
    public class RifleAttackStrategy : AttackStrategy , IReLoadAble
    {
        public RifleAttackStrategy(object owner) : base(owner)
        {

        }
        public override void Attack()
        {
            //��Ƽ�� �� ������ �� �� ������ ����
            if (player == null)
                return;
            Debug.Log("������ ���");
            //player.WeaponIndex = 0;
            // �ִϸ��̼ǿ��� ���������� ���� ������ ������ �κ��̴�.
            player.animator.SetInteger("WeaponType", 1);

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
            player.animator.SetFloat("ReloadType", 0.3f);
        }
    }

}
