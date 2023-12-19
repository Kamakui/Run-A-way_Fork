using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Object/Weapon Data", order = int.MaxValue)]
    public class WeaponData : ScriptableObject
    {
        public ItemType itemType;   //������ Ÿ��
        public string itemName;     //������ �̸�
        public Sprite image;        //������ �̹���
        public float damage;        //�� �����
        public int bullet;
        public int maxBullet;

        public WeaponData Clone 
        {
            get
            {
                return Instantiate(this);
            }
        }
    }
}
