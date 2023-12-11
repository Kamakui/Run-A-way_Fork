using Jinho;
using Hojun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float damage;
    public WeaponData parentWeaponData = null;
    // public PlayerController player = null;
    Action attackAction;

    IHitAble target;


    void OnEnable()
    {
        Invoke("BulletDestroy", 1.2f);  //�Ѿ��� �ҷ������� 1.2�� �� ������ �ı���
    }

    void Start()
    {
        //attackAction += BulletAttack;
    
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    void BulletDestroy()
    {
        Destroy(gameObject);
    }
    public void SetBulletData(WeaponData weaponData)    //���� damage �Է� �Լ�
    {
        //this.player = weaponData.player;
        parentWeaponData = weaponData;
        damage = parentWeaponData.damage;
    }
    public void SetBulletVec(Transform firePos, Vector3 targetPos)
    {
        transform.position = firePos.position;
        transform.rotation = firePos.rotation;
        transform.forward = (targetPos - transform.position).normalized;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IHitAble>( out IHitAble hitObj))
        {
            BulletDestroy();
            target = hitObj;
        }

    }


    // ���� ¥�� �ߴµ�, ���� ���� ������ �Ŷ� �� �ٸ���.. ������!! ��ȣ�� �� �� �� �־�.
    //public void Attack()
    //{
    //    attackAction();
    //}

    //public void BulletAttack()
    //{
    //    target.Hit(damage, this);
    //}

    //public GameObject GetAttacker()
    //{
    //    Debug.Log("�̰� �÷��̾� �Ѱ���� �ϴµ� ��ȣ�� �÷��̾� �����ؾ� �ȴٰ� �ؼ� ���� �� ��ȣ�� �� . ��");
    //    return null;
    //}

}
