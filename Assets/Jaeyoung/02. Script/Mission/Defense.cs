using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaeyoung
{
    public class Defense : Mission
    {
        [SerializeField] private float timeLimit;
        private float curTime;
        public float CurTime
        {
            get { return timeLimit; }
            set
            { 
                timeLimit = value;
                // ������ �� �̼� ���� UI����
            }
        }

        //private void Start()
        //{
        //    StartCoroutine(�̼� �ڷ�ƾ);   
        //}
        // ������ ���� ������ �̼��� ����ǵ��� �ڷ�ƾ ¥����
        // ������ �ٷ� ����

        public override void Play()
        {
            base.Play();
        }

        public override bool Condition()
        {
            // ���ѽð����� ����°�?
            return curTime >= timeLimit;
        }
    }
}
