using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Jaeyoung
{

    // ��� ����
    public class HearTest : Hojun.IHearStrategy
    {

    }

    //������ ������ ������Ʈ
    public class TestTarget : MonoBehaviour
    {
        public Hojun.IHearStrategy HearStrategy;
        public Hojun.StateMachine<TestTarget> stateMachine;
        public NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            stateMachine = new Hojun.StateMachine<TestTarget>(this);
            HearStrategy = new HearTest(this, 2.0f);
            //stateMachine.AddState(Hojun.MoveState.IDLE, );
            //stateMachine.AddState(Hojun.MoveState.WALK, );
            //stateMachine.AddState(Hojun.MoveState.RUN, );
            stateMachine.SetState(Hojun.MoveState.IDLE);
        }

        private void Update()
        {
            stateMachine.Update();
        }

    }
}