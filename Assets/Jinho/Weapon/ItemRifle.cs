using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public class ItemRifle : MonoBehaviour, IAttackable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData {  get { return weaponData; } }
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        Transform aimPos;           //�Ѿ��� ���ư� ��ġ
        public ItemType ItemType => weaponData.itemType;

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


            GameObject bulletObj = Instantiate(bullet);
            bulletObj.transform.position = firePos.position;
            bulletObj.transform.rotation = firePos.rotation;
        }
        public void Reload()
        {
            int needBulletCount = weaponData.maxBullet - weaponData.BulletCount;

            if (weaponData.TotalBullet >= needBulletCount)
                weaponData.BulletCount = weaponData.maxBullet;
            else
                weaponData.BulletCount += weaponData.TotalBullet;

            weaponData.TotalBullet -= needBulletCount;
        }
        public void SetItem(PlayerController player)
        {
            if (player.weaponObjSlot[0] != null)
            {
                GameObject temp = player.weaponObjSlot[0];
                temp.transform.position = transform.position;
                temp.GetComponent<IAttackable>().WeaponData.player = null;
                player.weaponObjSlot[0] = null;
                temp.SetActive(true);
            }
            weaponData.player = player;
            player.weaponObjSlot[0] = gameObject;
            player.weaponObjSlot[0].SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player) && weaponData.player == null)
            {
                SetItem(player);
            }
        }

    }
}
