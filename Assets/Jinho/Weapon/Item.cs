using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    #region Item_interface
    public enum ItemType
    {
        rifle,
        shotgun,
        Melee,
        Handgun,
        HealKit,
        Grenade,
    }
    public interface IUseable
    {
        public ItemType ItemType { get; }
        void Use();
        void Reload();
        void SetItem(PlayerController player);
    }
    public interface IAttackable : IUseable 
    {
        public WeaponData WeaponData { get; }
    }
    public interface IExpendable : IUseable { }
    #endregion

    #region ItemData_Class
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Object/Weapon Data", order = int.MaxValue)]
    public class WeaponData : ScriptableObject
    {
        public ItemType itemType;   //������ Ÿ��
        public string itemName;     //������ �̸�
        public Sprite image;        //������ �̹���
        public float damage;        //�� �����
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
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        public PlayerController player;
    }
    public class ExtendableData
    {
        public ItemType itemType;   //������ Ÿ��
        public string itemName;     //������ �̸�
        public Sprite image;        //������ �̹���
        public float effectValue;   //������ ȿ����ġ
        public PlayerController player;
    }
    #endregion

    #region WeaponClass
    public class Rifle : IAttackable
    {
        WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; set { weaponData = value; } }

        public ItemType ItemType => throw new System.NotImplementedException();

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            if (WeaponData.BulletCount == 0)
                return;
            WeaponData.BulletCount--;

        }
    }
    public class Shotgun : IAttackable
    {
        WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; set { weaponData = value; } }

        public ItemType ItemType => throw new System.NotImplementedException();

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            if (WeaponData.BulletCount == 0)
                return;
            WeaponData.BulletCount--;
        }
    }
    public class Melee : IAttackable
    {
        WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; set { weaponData = value; } }

        public ItemType ItemType => throw new System.NotImplementedException();

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {

        }
    }
    public class Handgun : IAttackable
    {
        WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; set { weaponData = value; } }

        public ItemType ItemType => throw new System.NotImplementedException();

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            if (WeaponData.BulletCount == 0)
                return;
            WeaponData.BulletCount--;

        }
    }
    public class Grenade : IAttackable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData => weaponData;
        public ItemType ItemType => throw new System.NotImplementedException();

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {

        }
    }
    #endregion

    #region ExtendableItemClass
    public class HealKit : IExpendable
    {
        ExtendableData extendableData;
        public ExtendableData ExtendableData { get => extendableData; set {  extendableData = value; } }

        public ItemType ItemType => throw new System.NotImplementedException();

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void SetItem(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void Use() 
        {
            
        }
    }
    #endregion

    public class Item : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }
    }
}
