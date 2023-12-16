using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hojun;


namespace Yeseoul
{


    public class Player : MonoBehaviour, IHitAble, IDieable
    {
        [SerializeField]
        CharacterData data;

        public CharacterData Data => throw new System.NotImplementedException();

        int killCount;
        public int KIllCount
        {
            get { return killCount; }
            set { killCount = value; }
        }

        public float Hp
        {
            get { return data.hp; }
            set
            {
                data.hp = value;
                if (data.hp <= 0)
                {
                    Die();
                }
            }
        }


        public void Attack()
        {
            GameObject target = GetAttacker();
        }

        public void Die()
        {
            //��������Ʈ�� ����. ������ �𸣴ϱ�. 
            //������ ����?
            //(�̱�)�̸� ���ӿ���
            //(��Ƽ)�̸� ķ ��ȯ? 
            //�ִϸ��̼�
        }

        public GameObject GetAttacker()
        {
            GameObject enemy = null;
            return enemy;
        }

        public void Hit(float damage, IAttackAble attacker)
        {
            Hp -= damage;
            //+ �ǰ� �ִϸ��̼� 
        }

        // Start is called before the first frame update
        void Start()
        {
            //data = new CharacterData(hp,speed,atk);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public float GetDamage()
        {
            throw new System.NotImplementedException();
        }

        public void Hit(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}