using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float damage;
    public Weapon parentWeapon = null;
    public PlayerController player = null;
    void OnEnable()
    {
        Invoke("BulletDestroy", 1.2f);  //�Ѿ��� �ҷ������� 1.2�� �� ������ �ı���
    }
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    void BulletDestroy()
    {
        Destroy(gameObject);
    }
    public void SetBulletData(PlayerController player, Weapon weapon)    //���� damage �Է� �Լ�
    {
        this.player = player;
        parentWeapon = weapon;
        damage = parentWeapon.damage;
    }
    void OnTriggerEnter(Collider other)
    {
        //if(other.TryGetComponent(out IHitable hit)
    }
}
