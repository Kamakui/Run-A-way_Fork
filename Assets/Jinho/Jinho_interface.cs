using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hojnun;
using Hojun;

namespace Jinho
{
    #region Item_interface
    public enum ItemType
    {
        rifle,
        shotgun,
        Melee,
        Handgun,
        HealKit,
        Grenade,
    }
    public interface IUseable
    {
        public ItemType ItemType { get; }
        public Player Player { get; set; }
        void Use();
        void Reload();
        void SetItem(Player player);
    }
    public interface IAttackItemable : IUseable
    {
        public WeaponData WeaponData { get; }
    }
    public interface IExpendable : IUseable
    {
        public ExtendableData ExtendableData { get; }
    }
    #endregion
    #region Weapon_Class

    public class WeaponItem
    {
        public static void SetWeapon(Player player, GameObject weaponObj, int slotIndex, Player weaponDataPlayer)
        {
            if (player.weaponObjSlot[slotIndex] != null)
            {

                GameObject temp = player.weaponObjSlot[slotIndex];
                Vector3 tempPos = weaponObj.transform.position;

                player.weaponObjSlot[slotIndex] = weaponObj;
                temp.GetComponent<IAttackItemable>().Player = null;
                temp.transform.position = tempPos;
                weaponObj.GetComponent<IAttackItemable>().Player = player;

                temp.SetActive(true);
                temp.GetComponent<Collider>().enabled = true;

                if (player.weaponIndex == slotIndex)   //�÷��̾ ������ ���⸦ ������� ��,
                {
                    player.attackState = weaponObj.GetComponent<IAttackItemable>().ItemType;  //player�� �� ������ ���⸦ �鵵�� ����
                    player.weapon = player.weaponObjSlot[slotIndex];
                }
                else                               //�÷��̾ ������ ���⸦ �������� ���� ��,
                    temp.SetActive(false);
            
            }
            else
            {           //�÷��̾��� ������ �������
                player.weaponObjSlot[slotIndex] = weaponObj;
                player.attackState = weaponObj.GetComponent<IAttackItemable>().ItemType;
                weaponObj.SetActive(false);
                weaponObj.GetComponent<IAttackItemable>().Player = player;
            }
            weaponObj.GetComponent<Collider>().enabled = false;
        }
    }
    #endregion
}
