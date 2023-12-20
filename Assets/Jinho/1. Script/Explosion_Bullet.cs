using Jaeyoung;
using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinho
{
    public class Explosion_Bullet : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        public float damage;
        public float explosionRadius;
        public WeaponData parentWeaponData = null;
        public Jinho.Player player = null;
        ExplosionComponent explosion;
        void OnEnable()
        {
            Invoke("BulletDestroy", 1.2f);  //�Ѿ��� �ҷ������� 1.2�� �� ������ �ı���
        }
        void Start()
        {
            explosion = GetComponent<ExplosionComponent>();
        }
        void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        void BulletDestroy()    //�Ѿ��� ObjectPool�� ���ư�
        {
            PoolingManager.instance.ReturnPool(gameObject);
        }
        public void SetBulletData(WeaponData weaponData, Jinho.Player player)    //���� damage �Է� �Լ�
        {
            this.player = player;
            parentWeaponData = weaponData;
            damage = parentWeaponData.damage;
        }
        public void SetBulletVec(Transform firePos, Vector3 targetPos)  //Bullet�� ��ġ, ȸ��, ���Ⱚ ����
        {
            transform.position = firePos.position;
            transform.rotation = firePos.rotation;
            transform.forward = (targetPos - transform.position).normalized;
        }
        public GameObject GetAttacker()
        {
            return player.gameObject;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hojun.IHitAble hit))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                explosion.Explosion(player.gameObject);
                BulletDestroy();
            }
        }
    }
}
