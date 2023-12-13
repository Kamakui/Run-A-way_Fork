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
            get { return curTime; }
            set
            {
                curTime = value;
                // ������ �� �̼� ���� UI����
            }
        }

        private void Start()
        {
            CurTime = 0;
            // StartCoroutine(�̼� �ڷ�ƾ);
        }
        // ������ ���� ������ �̼��� ����ǵ��� �ڷ�ƾ ¥����
        // ������ �ٷ� ����

        public override void Play()
        {
            CurTime += Time.deltaTime;
            base.Play();
        }

        public override bool Condition()
        {
            // ���ѽð����� ����°�?
            return curTime >= timeLimit;
        }
    }
}
