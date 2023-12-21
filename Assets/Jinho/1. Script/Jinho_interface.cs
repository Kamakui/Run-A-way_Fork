using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hojnun;
using Hojun;
using Gayoung;
using Photon.Pun;
using Photon.Realtime;
using Jaeyoung;

namespace Jinho
{
    #region Item_interface
    public enum ItemType
    {
        Rifle,
        Shotgun,
        Melee,
        Handgun,
        HealKit,
        Grenade,
    }
    public interface IUseable
    {
        public ItemType ItemType { get; }
        public Player Player { get; set; }
        public IAttackStrategy AttackStrategy { get; set; }
        public void Use();
        public void UseEffect();
        [PunRPC]
        public void SetItem(Player player);
    }
    public interface IAttackItemable : IUseable
    {
        public void Reloading();
        public void ReloadEffect();
    }
    public interface IExpendable : IUseable
    {
        public ExtendableData ExtendableData { get; }
    }
    #endregion
    #region Weapon_Class
    public class WeaponItem
    {
        
        public static void SetStrategy(Player player, GameObject weaponObj)
        {
            IAttackItemable attackItemable = weaponObj.GetComponent<IAttackItemable>();
            switch (attackItemable.ItemType)
            {
                case ItemType.Rifle:
                    attackItemable.AttackStrategy = new RifleAttackStrategy(player);
                    break;
                case ItemType.Shotgun:
                    attackItemable.AttackStrategy = new ShotGunStregy(player);
                    break;
                case ItemType.Handgun:
                    attackItemable.AttackStrategy = new HandgunAttackStrategy(player);
                    break;
                case ItemType.Melee:
                    attackItemable.AttackStrategy = new MeleeAttackStrategy(player);
                    break;
                case ItemType.HealKit:
                    //attackItemable.AttackStrategy = new HealKitAttackStrategy(player);
                    break;
                case ItemType.Grenade:
                    attackItemable.AttackStrategy = new GranadeAttackStrategy(player);
                    break;
            }
            player.attackStrategy = attackItemable.AttackStrategy;
        }
    }
    public class WeaponMonoBehaviour : MonoBehaviourPun
    {
        [SerializeField]protected WeaponData weaponData;
        public WeaponData WeaponData { get { return weaponData; } }

        [SerializeField]protected int maxTotalBullet;         //�ִ�� ���� ������ �ִ� �Ѿ��� �հ�
        [SerializeField]protected int totalBullet;            //���� ������ �ִ� �Ѿ��� �հ�
        [SerializeField]protected int maxBullet;       //�����Ǵ� �Ѿ� ��
        [SerializeField]protected int bulletCount;            //���� �ѿ� ����ִ� �Ѿ� ��

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
        [PunRPC]
        protected void SoundEffect(AudioClip clip, Transform transform)    //�Ҹ� ���
        {
            GameObject soundObj = PoolingManager.instance.PopObj(PoolingType.SOUND);
            soundObj.transform.position = transform.position;
            AudioSource sound = soundObj.GetComponent<AudioSource>();
            sound.clip = clip;
            soundObj.SetActive(true);
            sound.Play();
        }
        [PunRPC]
        protected void InstantiateEffect(GameObject effectObj, Transform transform)
        {
            Instantiate(effectObj, transform.position, transform.rotation);
        }

        [PunRPC]
        public void SetWeapon(Player player, GameObject weaponObj, int slotIndex, IUseable attackItemable = null)
        {
            if (player.weaponObjSlot[slotIndex] != null)
            {

                GameObject temp = player.weaponObjSlot[slotIndex];
                Vector3 tempPos = weaponObj.transform.position;

                player.weaponObjSlot[slotIndex] = weaponObj;
                temp.GetComponent<IUseable>().Player = null;

                temp.transform.position = tempPos;
                weaponObj.GetComponent<IUseable>().Player = player;

                temp.SetActive(true);
                temp.GetComponent<Collider>().enabled = true;

                if (player.weaponIndex == slotIndex)   //�÷��̾ ������ ���⸦ ������� ��,
                {
                    //SetStrategy(player, weaponObj);
                    player.attackState = weaponObj.GetComponent<IUseable>().ItemType;  //player�� �� ������ ���⸦ �鵵�� ����
                    player.currentItemObj = player.weaponObjSlot[slotIndex];
                    player.currentItem = player.currentItemObj.GetComponent<IUseable>();
                }
                else                               //�÷��̾ ������ ���⸦ �������� ���� ��,
                {
                    weaponObj.SetActive(false);
                }

            }
            else
            {           //�÷��̾��� ������ �������
                player.weaponObjSlot[slotIndex] = weaponObj;
                player.attackState = weaponObj.GetComponent<IUseable>().ItemType;
                weaponObj.SetActive(false);
                weaponObj.GetComponent<IUseable>().Player = player;
            }
            weaponObj.GetComponent<Collider>().enabled = false;
        }
    }
    #endregion
}
