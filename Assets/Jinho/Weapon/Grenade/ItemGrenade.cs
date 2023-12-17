using Gayoung;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yeseul;

namespace Jinho {
    public class ItemGrenade : MonoBehaviour, IAttackItemable, IInteractive
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; }
        public Player Player { get => player; set { player = value; } }
        Player player = null;
        public GameObject grenade;
        public float explosionRange;        //���� ����
        IAttackStrategy strategy;
        public ItemType ItemType { get => weaponData.itemType; }
        public IAttackStrategy AttackStrategy
        {
            get => strategy;
            set
            {
                strategy = value;
            }
        }
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
        void OnEnable()
        {
            strategy = new GranadeAttackStrategy(player);
        }
        public void Use()
        {
            
            if (BulletCount == 0)
                return;
            strategy.Attack();
        }

        public void SetItem(Player player)
        {
            WeaponItem.SetWeapon(player, gameObject, 3, this);
        }

        public void UseEffect()
        {
            BulletCount--;

            endPos = player.Aim.aimObjPos.position;
            GameObject bulletObj = Instantiate(grenade);
            bulletObj.GetComponent<Grenade>().SetGrenadeData(transform.position, endPos, player, explosionRange, weaponData.damage);
        }

        public void Interaction(GameObject interactivePlayer)
        {
            if (interactivePlayer.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
            }
        }
    }
}
