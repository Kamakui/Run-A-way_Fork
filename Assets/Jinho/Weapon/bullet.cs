using Jinho;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float damage;
    public WeaponData parentWeaponData = null;
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
    public void SetBulletData(WeaponData weaponData)    //���� damage �Է� �Լ�
    {
        this.player = weaponData.player;
        parentWeaponData = weaponData;
        damage = parentWeaponData.damage;
    }
    void OnTriggerEnter(Collider other)
    {
        //if(other.TryGetComponent(out IHitable hit)
    }
}
