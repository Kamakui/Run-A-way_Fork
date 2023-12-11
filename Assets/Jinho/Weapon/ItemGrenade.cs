using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho {
    public class ItemGrenade : MonoBehaviour, IAttackable
    {
        public WeaponData weaponData;
        public WeaponData WeaponData { get => weaponData; }
        public float explosionRange;        //���� ����
        public ItemType ItemType { get => weaponData.itemType; }
        Vector3 endPos, startPos;           //���ư� ��ġ
        public void Use()
        {
            /*
            if (weaponData.BulletCount == 0)
                return;
            weaponData.BulletCount--;
            */
            startPos = transform.position;
            //endPos = weaponData.player.aimPos;
            StartCoroutine(MoveCo());
        }
        public void Reload()    //����ź�� reload ����
        {
            return;
        }
        public void SetItem(PlayerController player)
        {
            if (player.weaponObjSlot[3] != null)
            {
                GameObject temp = player.weaponObjSlot[3];
                temp.transform.position = transform.position;
                temp.GetComponent<IAttackable>().WeaponData.player = null;
                player.weaponObjSlot[3] = null;
                temp.SetActive(true);
            }
            weaponData.player = player;
            player.weaponObjSlot[3] = gameObject;
            player.weaponObjSlot[3].SetActive(false);
        }
        IEnumerator MoveCo()            //�������� ��ġ�� ���ư��� �Լ�
        {
            float timer = 0;
            while (true)
            {
                timer += Time.deltaTime;
                transform.position = Parabola(startPos, endPos, Vector3.Distance(startPos, endPos) / 2, timer);
                yield return new WaitForEndOfFrame();
            }
        }
        Vector3 Parabola(Vector3 start, Vector3 end, float height, float time)      //������ ���ϴ� ����
        {
            Func<float, float> f = x => -4 * height * x * x + 4 * height * x;       //  y = -4ax^2 + 4ax + 0 = f(x)
            var mid = Vector3.Lerp(start, end, time);                                     //mid = x;
            return new Vector3(mid.x, f(time) + Mathf.Lerp(start.y, end.y, time), mid.z);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player) && weaponData.player == null)
            {
                SetItem(player);
            }
            GetComponent<ExplosionComponent>().Explosion(weaponData.damage, explosionRange);
            gameObject.SetActive(false);
        }
    }
}
