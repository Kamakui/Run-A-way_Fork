using Hojun;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionComponent : MonoBehaviour, IAttackAble
{
    public float explosionRange;        //���� ����
    public float damage;                //���� �����
    public GameObject effectObj;        //���� ����Ʈ
    public AudioClip effectSound;       //���� ����
    public Jinho.Player player;
    Hojun.IHitAble target;
    public void Attack()
    {
        target.Hit(damage, this);
    }
    public GameObject GetAttacker()
    {
        return player.gameObject;
    }
    public void Explosion(float damage, float explosionRange = 0, Jinho.Player player = null) //����
    {
        this.damage = damage;
        this.explosionRange = explosionRange;
        this.player = player;
        //����Ʈ + ���� �߻�
        GameObject effectObj = PoolingManager.instance.PopObj(Jaeyoung.PoolingType.SOUND);
        //Destroy(effectObj);
        Destroy(gameObject, 6.0f);
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRange);
        if(cols.Length > 0)
        {
            foreach(var col in cols)
            {
                if (col.TryGetComponent(out Hojun.IHitAble hitable))
                {
                    target = hitable;
                    Attack();
                }
            }
        }
    }

    public float GetDamage()
    {
        throw new System.NotImplementedException();
    }
}
