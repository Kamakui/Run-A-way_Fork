using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jinho_Weapon
{
    public abstract class Weapon
    {
        public Sprite image;        //�ѱ� ���� �̹���
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
        public Weapon(Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, GameObject bullet)
        {
            this.image = image;
            this.damage = damage;
            this.maxBullet = maxBullet;
            BulletCount = bulletCount;
            this.maxTotalBullet = maxTotalBullet;
            TotalBullet = totalBullet;
            this.firePos = firePos;
            this.bullet = bullet;
        }

        public abstract void Fire();
        public abstract void Reload();
    }
    public class Rifle : Weapon
    {
        public Rifle(Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, GameObject bullet) : base(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet)
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
        public Shotgun(Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, GameObject bullet) : base(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet)
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
        public Handgun(Sprite image, float damage, int maxBullet, int bulletCount, int maxTotalBullet, int totalBullet, Transform firePos, GameObject bullet) : base(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet)
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
        public Weapon weapon = null;

        public Sprite image;               //�ѱ� ���� �̹���
        public float damage;               //�� �����
        public int maxBullet;              //�����Ǵ� �Ѿ� ��
        public int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��
        public int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        public int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        public Transform firePos;          //�Ѿ� �߻� ��ġ
        public GameObject bullet;          //���ư� �Ѿ� GameObject
        void Start()
        {
            SetWeapon();
        }
        void SetWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.Rifle:
                    weapon = new Rifle(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet);
                    break;
                case WeaponType.Shotgun:
                    weapon = new Rifle(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet);
                    break;
                case WeaponType.Handgun:
                    weapon = new Rifle(image, damage, maxBullet, bulletCount, maxTotalBullet, totalBullet, firePos, bullet);
                    break;
            }
        }
    }
}
