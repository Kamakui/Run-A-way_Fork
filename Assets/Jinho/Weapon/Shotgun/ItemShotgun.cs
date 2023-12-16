using Gayoung;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Jinho
{
    public class ItemShotgun : MonoBehaviour, IAttackItemable, Yeseul.IInteractive
    {
        public WeaponData WeaponData 
        { 
            get => weaponData;
        }
        [SerializeField] WeaponData weaponData;

        public Player Player 
        { 
            get => player;
            set { player = value; }
        }
        [SerializeField] Player player = null;

        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        IAttackStrategy strategy;
        Transform AimPos
        {
            get => player.Aim.aimObjPos; //�Ѿ��� ���ư� ��ġ
        }


        public ItemType ItemType => weaponData.itemType;
        public IAttackStrategy AttackStrategy => strategy;
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
        public Collider weaponCol;
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

        void SetTransform(Vector3[] array)   //��� ���� �Ѿ� 9���� ������ ��ǥ
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.insideUnitSphere * 1.0f + AimPos.position;    //aimPos���� ���� �� ���� ���� ���� ��ǥ�� ����
            }
        }
        void OnEnable()
        {
            strategy = new ShotGunStregy(player);
        }
        public void Use()
        {
            
            if (BulletCount == 0)
                return;
            BulletCount--;
            
            //����Ʈ + ����
            Vector3[] targetPosArray = new Vector3[9];
            SetTransform(targetPosArray);

            //�Ѿ��� ������ ȿ��
            for(int i=0; i<targetPosArray.Length; i++)
            {
                //GameObject bulletObj = Instantiate(bullet);
                GameObject bulletObj = PoolingManager.instance.PopObj(PoolingType.BULLET);
                Bullet_Component bulletScript = bulletObj.GetComponent<Bullet_Component>();
                bulletScript.SetBulletData(weaponData, Player);
                bulletScript.SetBulletVec(firePos, targetPosArray[i]);
            }
        }

        public void Reload()
        {
            if (BulletCount == maxBullet) 
                return;
            BulletCount += 1;
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

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public GameObject GetAttacker()
        {
            throw new System.NotImplementedException();
        }

        public float GetDamage()
        {
            throw new System.NotImplementedException();
        }

        public void UseEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
