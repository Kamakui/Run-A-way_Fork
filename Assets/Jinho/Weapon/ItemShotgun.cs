using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Jinho
{
    public class ItemShotgun : MonoBehaviour, IAttackable
    {
        public WeaponData weaponData;
        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        Transform aimPos;           //�Ѿ��� ���ư� ��ġ
        public ItemType ItemType => weaponData.itemType;
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
            Vector3[] targetPosArray = new Vector3[9];
            SetTransform(targetPosArray);
            //�Ѿ��� ������ ȿ��
            for(int i=0; i<targetPosArray.Length; i++)
            {
                GameObject bulletObj = Instantiate(bullet);
                bulletObj.GetComponent<bullet>().SetBulletData(weaponData);
                bulletObj.GetComponent<bullet>().SetBulletVec(firePos, targetPosArray[i]);
            }
        }
        public void Reload()
        {
            if (weaponData.BulletCount == weaponData.maxBullet) return;
            weaponData.BulletCount += 1;
        }
        public void SetItem(PlayerController player)
        {
            if (player.weaponObjSlot[0] != null)
            {
                GameObject temp = player.weaponObjSlot[0];
                temp.transform.position = transform.position;
                temp.SetActive(true);
                player.weaponObjSlot[0] = null;
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
