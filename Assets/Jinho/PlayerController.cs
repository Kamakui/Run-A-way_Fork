using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    #region Player_interface
    interface IMoveStrategy
    {
        void Moving();
    }
    interface IAttackStrategy
    {
        void Attack();
    }
    public enum PlayerMoveState
    {
        idle,
        walk,
        run,
        dead,
    }
    public enum PlayerAttackState
    {
        gun,
        melee,
        sub,
        heal,
        granade,
    }
    #endregion
    public class Job
    {
        public string name;
        public float maxHp;
        public float moveSpeed;
    }
    #region MoveStrategy_Class
    public class Idle : IMoveStrategy
    {
        PlayerController player = null;
        public Idle(object owner)
        { 
            player = (PlayerController)owner;
        }
        public void Moving()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                player.moveState = PlayerMoveState.walk;
        }
    }
    public class Walk : IMoveStrategy
    {
        PlayerController player = null;
        public Walk(object owner) 
        {
            player = (PlayerController)owner;
        }
        public void Moving()
        {
            Vector3 vec = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                player.moveState = PlayerMoveState.run;

            if (Input.GetKey(KeyCode.A))
            {
                vec += Vector3.left;
                //�������� �̵� �ִ�
            }
            if (Input.GetKey(KeyCode.W))
            {
                vec += Vector3.forward;
                //�������� �̵� �ִ�
            }
            if (Input.GetKey(KeyCode.D))
            {
                vec += Vector3.right;
                //���������� �̵� �ִ�
            }
            if (Input.GetKey(KeyCode.S))
            {
                vec += Vector3.back;
                //�ڷ� �̵� �ִ�
            }

            if(vec == Vector3.zero)
                player.moveState = PlayerMoveState.idle;
            player.transform.Translate(vec.normalized * player.state.MoveSpeed * Time.deltaTime);
        }
    }
    public class Run : IMoveStrategy
    {
        PlayerController player = null;
        public Run(object owner)
        {
            player = (PlayerController)owner;
        }
        public void Moving()
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(Vector3.forward * (player.state.MoveSpeed * 1.2f) * Time.deltaTime);
                //�޸��� �ִ�
            }
            if(Input.GetKeyUp(KeyCode.LeftShift))
                player.moveState= PlayerMoveState.walk;
        }
    }
    #endregion
    #region AttackStrategy_class
    public class GunAttackStrategy : IAttackStrategy
    {
        PlayerController player = null;
        public GunAttackStrategy(object owner)
        {
            player = (PlayerController)owner;
        }
        public void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.weaponSlot[0].Fire();
                //�ֹ��� �߻� �ִ�
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

            }
        }
    }
    public class MeleeAttackStrategy : IAttackStrategy
    {
        PlayerController player = null;
        public MeleeAttackStrategy(object owner)
        {
            player = (PlayerController)owner;
        }
        public void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.currentWeapon.Fire();
                //���� ���� �ִ�
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //���� ��ü �ִ�
                player.currentWeapon = player.weaponSlot[0];
                player.attackState = player.currentWeapon.attackState;
            }
        }
    }
    public class GranadeAttackStrategy : IAttackStrategy
    {
        PlayerController player = null;
        public GranadeAttackStrategy(object owner)
        {
            player = (PlayerController)owner;
        }
        public void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.currentWeapon.Fire();
                //����ź ��ô �ִ�
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //���� ��ü �ִ�
            }
        }
    }
    #endregion
    public class PlayerState
    {
        public Job job;
        public float DefaultMoveSpeed => 3;
        public float DefaultMaxHp => 200;
        float moveSpeed;
        public float MoveSpeed
        {
            get { return moveSpeed; } 
            set 
            { 
                moveSpeed = value;
            }
        }
        float maxHp;
        public float MaxHp 
        {
            get { return maxHp; }
            set { maxHp = value; }
        }
        float hp;
        public float Hp
        {
            get { return hp; }
            set 
            { 
                hp = value;
                if (hp <= 0)
                    hp = 0;
                if(hp > MaxHp)
                    hp = MaxHp;
            }
        }
        public PlayerState(Job job = null)
        {
            if (job == null)
            {
                this.job = null;
                moveSpeed = DefaultMoveSpeed;
                MaxHp = DefaultMaxHp;
            }
            else
            {
                this.job = job;
                moveSpeed = job.moveSpeed;
                MaxHp = job.maxHp;
            }
        }
    }
    public class PlayerController : MonoBehaviour
    {
        public PlayerState state;                                   //player�� �⺻state
        public Weapon[] weaponSlot = new Weapon[4];                 //weapon slot
        public Weapon currentWeapon = null;                         //���� ����ִ� weapon

        public PlayerMoveState moveState;                           //���� move����
        public PlayerAttackState attackState;                       //���� attack����
        Dictionary<PlayerMoveState, IMoveStrategy> moveDic;         //move ���� dictionary
        Dictionary<PlayerAttackState, IAttackStrategy> attackDic;   //attack ���� dictionary
        void Start()
        {
            state = new PlayerState();

            moveDic = new Dictionary<PlayerMoveState, IMoveStrategy>();
            moveDic.Add(PlayerMoveState.idle, new Idle(this));
            moveDic.Add(PlayerMoveState.walk, new Walk(this));
            moveDic.Add(PlayerMoveState.run, new Run(this));

            attackDic.Add(PlayerAttackState.gun, new GunAttackStrategy(this));
            attackDic.Add(PlayerAttackState.melee, new MeleeAttackStrategy(this));
            attackDic.Add(PlayerAttackState.granade, new GranadeAttackStrategy(this));

            moveState = PlayerMoveState.idle;
            attackState = PlayerAttackState.gun;
        }

        void Update()
        {
            moveDic[moveState]?.Moving();
            if (Input.GetKey(KeyCode.Mouse0) && currentWeapon != null)
                currentWeapon?.Fire();
        }
    }
}
