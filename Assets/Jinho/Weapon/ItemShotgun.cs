using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Jinho
{
    public class ItemShotgun : MonoBehaviour, IAttackItemable, Yeseul.IInteractive
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get { return weaponData; } }
        public Player Player { get => player; set { player = value; } }
        [SerializeField] Player player = null;
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        Transform aimPos;           //�Ѿ��� ���ư� ��ġ
        public ItemType ItemType => weaponData.itemType;
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        [SerializeField] int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
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
        [SerializeField] int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        [SerializeField] int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
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
        public Collider weaponCol;
        void SetTransform(Vector3[] array)   //��� ���� �Ѿ� 9���� ������ ��ǥ
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.insideUnitSphere * 1.0f + aimPos.position;    //aimPos���� ���� �� ���� ���� ���� ��ǥ�� ����
            }
        }
        public void Use()
        {
            /*
            if (weaponData.BulletCount == 0)
                return;
            weaponData.BulletCount--;
            */
            //����Ʈ + ����
            Vector3[] targetPosArray = new Vector3[9];
            aimPos = player.Aim.aimObjPos;
            SetTransform(targetPosArray);
            //�Ѿ��� ������ ȿ��
            for(int i=0; i<targetPosArray.Length; i++)
            {
                //GameObject bulletObj = Instantiate(bullet);
                GameObject bulletObj = PoolingManager.instance.PopObj(PoolingType.BULLET);
                Bullet bulletScript = bulletObj.GetComponent<Bullet>();
                bulletScript.SetBulletData(weaponData, Player);
                bulletScript.SetBulletVec(firePos, targetPosArray[i]);
            }
        }
        public void Reload()
        {
            if (BulletCount == maxBullet) return;
                BulletCount += 1;
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
                if(player.weapon != null)
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
