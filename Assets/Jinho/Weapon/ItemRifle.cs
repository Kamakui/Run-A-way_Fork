using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public class ItemRifle : MonoBehaviour, IAttackItemable, Yeseul.IInteractive
    {
        public WeaponData weaponData;
        public WeaponData WeaponData {  get { return weaponData; } }
        public Player Player {  get=> player; set { player = value; } }
        [SerializeField] Player player = null;
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        Transform aimPos;           //�Ѿ��� ���ư� ��ġ
        public ItemType ItemType => weaponData.itemType;
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        [SerializeField]int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
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
        [SerializeField]int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        [SerializeField]int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
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
            /*
            if (weaponData.BulletCount == 0)
                return;
            weaponData.BulletCount--;
            
            //�Ѿ��� ������ ȿ��
            GameObject bulletObj = Instantiate(bullet);
            bulletObj.GetComponent<bullet>().SetBulletData(weaponData);
            bulletObj.GetComponent<bullet>().SetBulletVec(firePos, aimPos.position);
            */
            //�Ѿ��� ������ ȿ��
            //����Ʈ + ����

            aimPos = player.Aim.aimObjPos;
            GameObject bulletObj = PoolingManager.instance.PopObj(PoolingType.BULLET);
            Bullet bulletScript = bulletObj.GetComponent<Bullet>();
            bulletScript.SetBulletData(weaponData, Player);
            bulletScript.SetBulletVec(firePos, aimPos.position);
        }
        public void Reload()
        {
            int needBulletCount = maxBullet - BulletCount;

            if (TotalBullet >= needBulletCount)
                BulletCount = maxBullet;
            else
                BulletCount += TotalBullet;

            TotalBullet -= needBulletCount;
        }
        public void SetItem(Player player)
        {
            if (player.weaponObjSlot[0] != null)
            {
                GameObject temp = player.weaponObjSlot[0];
                Vector3 tempPos = transform.position;
                if (player.weapon == player.weaponObjSlot[0])   //�÷��̾ ������ ���⸦ ������� ��,
                {
                    player.weapon = null;
                    player.attackState = ItemType;
                    player.weapon = gameObject;
                    temp.GetComponent<IAttackItemable>().Player = null;
                }
                else
                {                                               //�÷��̾ ������ ���⸦ �������� ���� ��,
                    player.weaponObjSlot[0] = null;
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
            player.weaponObjSlot[0] = gameObject;
        }

        public void Interaction(GameObject interactivePlayer)
        {
            if (interactivePlayer.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
            }
        }
        private void OnTriggerEnter(Collider other)
        {

        }
    }
}
