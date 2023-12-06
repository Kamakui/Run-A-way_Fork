using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Hojun;
using UnityEditor;


namespace Hojun 
{

    public enum MoveState
    {
        IDLE,
        WALK,
        RUN
    }

    


    public class NormalZombie : Zombie, IMoveAble
    {
        //fdsfdsf
        Vector3 myvec;

        public new void Awake()
        {
            myvec = gameObject.transform.localPosition;

            //fsfsd
            base.Awake();
            stateMachine = new StateMachine<Zombie>(this);
            stateMachine.AddState(MoveState.IDLE, new IdleState(stateMachine));
        }

        // Start is called before the first frame update
        void Start()
        {
            //�Ծ���
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();
        }




    }



}
