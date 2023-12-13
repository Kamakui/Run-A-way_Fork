using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho {
    public class ItemGrenade : MonoBehaviour, IAttackItemable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; }
        public Player Player { get => player; set { player = value; } }
        Player player = null;
        public GameObject grenade;
        public float explosionRange;        //���� ����
        public ItemType ItemType { get => weaponData.itemType; }
        Vector3 endPos, startPos;           //���ư� ��ġ
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int BulletCount
        {
            get { return bulletCount; }
            set
            {
                bulletCount = value;
                if (bulletCount > maxBullet) bulletCount = maxBullet;
                if (bulletCount < 0) bulletCount = 0;
            }
        }
        int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public int TotalBullet
        {
            get { return totalBullet; }
            set
            {
                totalBullet = value;
                if (totalBullet > maxTotalBullet) totalBullet = maxTotalBullet;
                if (totalBullet < 0) totalBullet = 0;
            }
        }
        public void Use()
        {
            
            if (BulletCount == 0)
                return;
            BulletCount--;
            
            endPos = player.Aim.aimObjPos.position;
            GameObject bulletObj = Instantiate(grenade);
            bulletObj.GetComponent<Grenade>().SetGrenadeData(transform.position, endPos, player, explosionRange, weaponData.damage);
        }
        public void Reload()    //����ź�� reload ����
        {
            return;
        }
        public void SetItem(Player player)
        {
            WeaponItem.SetWeapon(player, gameObject, 3, this.player);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
            }
        }
    }
}
