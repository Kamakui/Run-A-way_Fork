using Hojun;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hojun
{

    public class ZombieData
    {
        float hp;
        float speed;
        bool isDead;
        float attack;

        public ZombieData(float hp , float spped , float attack) 
        {
            this.hp = hp;
            this.speed = spped;
            this.isDead = false;
            this.attack = attack;
        }

        public float Hp { get => hp;}
        public float Speed { get => speed;}
        public bool IsDead { get => isDead;}
        public float Attack { get => attack;}

    }


    public abstract class Zombie : Character, IMoveAble 
    { 

        public enum ZombieState
        {
            IDLE,
            SEARCH,
            FIND
        }

        public enum ZombieMove
        {
            IDLE,
            WALK,
            RUN
        }
    

        protected StateMachine<Zombie> stateMachine;
        public ZombieData zombieData;
        public HearComponent hearComponent;

        public float hearValue;

        public ZombieData Data { get => zombieData;}

        public Transform traceTarget;
        public Vector3 destination;


        protected Dictionary<ZombieMove, IMoveStrategy> moveDict = new Dictionary<ZombieMove, IMoveStrategy>();
        protected Dictionary<ZombieState, State> stateDict = new Dictionary<ZombieState, State>();


        public IMoveStrategy GetMoveDict(ZombieMove move)
        {
            return moveDict[move];
        }

        public IMoveStrategy MoveStrategy { get => moveStrategy; set { moveStrategy = value; } }
        IMoveStrategy moveStrategy;

        protected void Awake()
        {
            stateMachine = new StateMachine<Zombie>(this);
            hearComponent = GetComponent<HearComponent>();
            zombieData = new ZombieData(50,10,20);
        }


        public virtual void Move() 
        {
            if (traceTarget != null)
                moveStrategy.Move(traceTarget.gameObject);

            else if(destination != Vector3.negativeInfinity)
                MoveStrategy.Move(destination);
        }

        public void Hear(GameObject soundOwner)
        {

            // hear
            // TODOLIST
            // movestrategy�� ����� ������ tractarget , destination ���� �� �ֱ�
            // �ش� ������ soundOwner���� �����ؼ� ������ ��

            throw new System.NotImplementedException();
        }



    }



}
