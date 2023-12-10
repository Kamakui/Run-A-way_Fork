using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public class ItemMelee : MonoBehaviour, IAttackable
    {
        public WeaponData weaponData;
        public Collider col;
        public ItemType ItemType => weaponData.itemType;
        public void Use()
        {
            //Colldier�� ������ ����
            col.enabled = !col.enabled;
        }
        public void Reload()    //��������� ������ ����
        {
            return;
        }
        public void SetItem(PlayerController player)
        {
            if (player.weaponObjSlot[1] != null)
            {
                GameObject temp = player.weaponObjSlot[1];
                temp.transform.position = transform.position;
                temp.SetActive(true);
                player.weaponObjSlot[1] = null;
            }
            weaponData.player = player;
            player.weaponObjSlot[1] = gameObject;
            player.weaponObjSlot[1].SetActive(false);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player) && weaponData.player == null)
            {
                SetItem(player);
                col = gameObject.GetComponent<Collider>();
            }
            //if(other.TryGetComponent(out IHitable hit))
        }
    }
}
