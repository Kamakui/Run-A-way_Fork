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
        public AudioClip gunFireSound;
        public void Use()
        {
            
            if (BulletCount == 0)
                return;
            BulletCount--;

            //����Ʈ + ����
            GameObject soundObj = PoolingManager.instance.PopObj(PoolingType.SOUND);
            soundObj.transform.position = firePos.position;
            soundObj.GetComponent<AudioSource>().clip = gunFireSound;
            soundObj.SetActive(true);
            
            //�Ѿ��� ������ ȿ��
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
            WeaponItem.SetWeapon(player, gameObject, 0, this.player);
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
