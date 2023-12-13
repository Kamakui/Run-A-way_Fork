using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    [CreateAssetMenu(fileName = "ExtenableData", menuName = "Scriptable Object/Extenable Data", order = int.MaxValue)]
    public class ExtendableData : ScriptableObject
    {
        public ItemType itemType;   //������ Ÿ��
        public string itemName;     //������ �̸�
        public Sprite image;        //������ �̹���
        public float effectValue;   //������ ȿ����ġ
    }
}
