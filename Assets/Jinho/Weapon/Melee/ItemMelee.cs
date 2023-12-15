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

        public Hojun.IAttackStrategy AttackStrategy => throw new System.NotImplementedException();

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
            WeaponItem.SetWeapon(player, gameObject, 1, this.player);
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

        public float GetDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
