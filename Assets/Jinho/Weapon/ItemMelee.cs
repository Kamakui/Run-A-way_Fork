using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public class ItemMelee : MonoBehaviour, IAttackItemable, Yeseul.IInteractive, Hojun.IAttackAble
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get { return weaponData; } }
        public Player Player { get => player; set { player = value; } }
        [SerializeField] Player player = null;
        public Collider col;
        public ItemType ItemType => weaponData.itemType;
        public void Use()
        {
            //Colldier�� ������ ����
            //����
            col.enabled = !col.enabled;
        }
        public void Reload()    //��������� ������ ����
        {
            return;
        }
        public void SetItem(Player player)
        {
            if (player.weaponObjSlot[1] != null)
            {
                GameObject temp = player.weaponObjSlot[1];
                Vector3 tempPos = transform.position;
                if (player.weapon == player.weaponObjSlot[1])   //�÷��̾ ������ ���⸦ ������� ��,
                {
                    player.weapon = null;
                    player.attackState = ItemType;
                    player.weapon = gameObject;
                    temp.GetComponent<IAttackItemable>().Player = null;
                }
                else
                {                                               //�÷��̾ ������ ���⸦ �������� ���� ��,
                    player.weaponObjSlot[1] = null;
                    temp.transform.position = tempPos;
                    temp.GetComponent<IAttackItemable>().Player = null;
                    temp.SetActive(true);
                }
            }
            else
            {           //�÷��̾��� ������ �������
                //player.weaponObjSlot[0].SetActive(false);
                if (player.weapon != null)
                {
                    player.weapon = gameObject;
                    player.attackState = ItemType;
                }
            }
            this.player = player;
            player.weaponObjSlot[1] = gameObject;
        }
        public void Interaction(GameObject interactivePlayer)
        {
            if (interactivePlayer.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
                col = gameObject.GetComponent<Collider>();
            }
        }
        public void Attack()
        {
            //������ ��, �Ͼ�� ȿ��?
            return;
        }
        public GameObject GetAttacker()
        {
            return gameObject;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) == this.player) 
            {
                Debug.Log(other.name + "��(��) �����̴�.");
                return;
            }
            if(other.TryGetComponent(out Hojun.IHitAble hit))
            {
                hit.Hit(weaponData.damage, this);
            }
        }
    }
}
