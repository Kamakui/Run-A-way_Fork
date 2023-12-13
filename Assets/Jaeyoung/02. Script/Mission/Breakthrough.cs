using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaeyoung
{
    public class Breakthrough : Mission
    {
        public int groupCount;
        [SerializeField] private int curCount;
        public int CurCount
        {
            get { return curCount; }
            set
            { 
                curCount = value;
                // ������ �� �̼� ���� UI����
            }
        }

        //private void Start()
        //{
        //    // ����ִ� �ο����� groupCount�� �־������
        //    // groupCount = �������� ������Ʈ?
        //}

        public override bool Condition()
        {
            // �÷��̾ Ư�� ��ġ�� �ο��� ��ŭ 
            return curCount == groupCount;
        }

        public override void Play()
        {
            base.Play();
        }
    }
}