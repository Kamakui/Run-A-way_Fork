using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jinho
{
    public class Weapon
    {
        public string name;         //�ѱ� �̸�
        public Sprite image;        //�ѱ� ���� �̹���
        public PlayerAttackState attackState;   //���� ���
        public float damage;        //�� �����
        public int maxBullet;       //�����Ǵ� �Ѿ� ��
        int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int BulletCount
        {
            get { return bulletCount; }
            set 
            {
                bulletCount = value;
                if(bulletCount > maxBullet) bulletCount = maxBullet;
                if(bulletCount < 0 ) bulletCount = 0;
            }
        }
        int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public int TotalBullet
        {
            get { return  totalBullet; }
            set 
            {
                totalBullet = value; 
                if(totalBullet > maxTotalBullet) totalBullet = maxTotalBullet;
                if(totalBullet < 0 ) totalBullet = 0;
            }
        }

        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        public Weapon(string name, Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, PlayerAttackState attackState, GameObject bullet = null)
        {
            this.name = name;
            this.image = image;
            this.attackState = attackState;
            this.damage = damage;
            this.maxBullet = maxBullet;
            BulletCount = bulletCount;
            this.maxTotalBullet = maxTotalBullet;
            TotalBullet = totalBullet;
            this.firePos = firePos;
            this.bullet = bullet;
        }

        public virtual void Fire() { }
        public virtual void Reload() { }
    }
    public class Rifle : Weapon
    {
        public Rifle(string name, Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, PlayerAttackState attackState, GameObject bullet) : base(name, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet)
        {
        }

        public override void Fire()
        {
            Debug.Log("������ ��!");
        }
        public override void Reload()
        {
            Debug.Log("������ ������~");
        }
    }
    public class Shotgun : Weapon
    {
        public Shotgun(string name, Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, PlayerAttackState attackState, GameObject bullet) : base(name, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet)
        {
        }

        public override void Fire()
        {
            
        }
        public override void Reload()
        {

        }
    }
    public class Handgun : Weapon
    {
        public Handgun(string name, Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, PlayerAttackState attackState, GameObject bullet) : base(name, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet)
        {
        }

        public override void Fire()
        {
            
        }
        public override void Reload()
        {
            
        }
    }
    public class WeaponClass : MonoBehaviour
    {
        public enum WeaponType
        {
            Rifle,
            Shotgun,
            Handgun,
        }
        public WeaponType weaponType;
        public PlayerAttackState attackState;
        public Weapon weapon = null;

        public string weaponName;          //���� �̸�
        public Sprite image;               //�ѱ� ���� �̹���
        public float damage;               //�� �����
        public int maxBullet;              //�����Ǵ� �Ѿ� ��
        public int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        public int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public Transform firePos;          //�Ѿ� �߻� ��ġ
        public GameObject bullet;          //���ư� �Ѿ� GameObject
        void Awake()
        {
            SetWeapon();
        }
        void SetWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.Rifle:
                    weapon = new Rifle(weaponName, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet);
                    break;
                case WeaponType.Shotgun:
                    weapon = new Shotgun(weaponName, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet);
                    break;
                case WeaponType.Handgun:
                    weapon = new Handgun(weaponName, image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, attackState, bullet);
                    break;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerController player))
            {
                player.weaponSlot[0] = weapon;
                player.currentWeapon = player.weaponSlot[0];
                gameObject.SetActive(false);
            }
        }
    }
}
