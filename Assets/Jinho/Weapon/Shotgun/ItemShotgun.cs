using Gayoung;
using Jaeyoung;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Jinho
{
    public class ItemShotgun : WeaponMonoBehaviour, IAttackItemable, Yeseul.IInteractive, IReLoadAble
    {
        public WeaponData WeaponData 
        { 
            get => weaponData;
        }
        [SerializeField] WeaponData weaponData;

        public Player Player 
        { 
            get => player;
            set 
            { 
                player = value;
                if(player != null)
                {
                    strategy = new ShotGunStregy(player);
                }
            }
        }
        [SerializeField] Player player = null;

        public Transform firePos;   //�Ѿ� �߻� ��ġ
        public GameObject bullet;   //���ư� �Ѿ� GameObject
        public AudioClip gunFireSound;
        IAttackStrategy strategy;
        Transform AimPos
        {
            get => player.Aim.aimObjPos; //�Ѿ��� ���ư� ��ġ
        }


        public ItemType ItemType => weaponData.itemType;
        public IAttackStrategy AttackStrategy
        {
            get => strategy;
            set
            {
                strategy = value;
            }
        }

        public SoundComponent sound;
        public Collider weaponCol;

        void SetTransform(Vector3[] array)   //��� ���� �Ѿ� 9���� ������ ��ǥ
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.insideUnitSphere * 1.0f + AimPos.position;    //aimPos���� ���� �� ���� ���� ���� ��ǥ�� ����
            }
        }
        void OnEnable()
        {
            strategy = new ShotGunStregy(player);
        }
        public void Use()
        {
            if (BulletCount == 0)
                return;
            
            strategy.Attack();
        }

        public void MakeBullet()
        {
            //BulletCount--;
            // make bullet -> obj_pull

            //����Ʈ + ����
            Vector3[] targetPosArray = new Vector3[9];
            SetTransform(targetPosArray);

            //�Ѿ��� ������ ȿ��
            for (int i = 0; i < targetPosArray.Length; i++)
            {
                //GameObject bulletObj = Instantiate(bullet);
                GameObject bulletObj = PoolingManager.instance.PopObj(PoolingType.BULLET);
                Bullet_Component bulletScript = bulletObj.GetComponent<Bullet_Component>();
                bulletScript.SetBulletData(weaponData, Player);
                bulletScript.SetBulletVec(firePos, targetPosArray[i]);
            }
            this.sound.ActiveSound();
            GameObject soundObj = PoolingManager.instance.PopObj(PoolingType.SOUND);
            soundObj.transform.position = firePos.position;
            AudioSource sound = soundObj.GetComponent<AudioSource>();
            sound.clip = gunFireSound;
            soundObj.SetActive(true);
            sound.Play();
        }


        public void SetItem(Player player)
        {
            WeaponItem.SetWeapon(player, gameObject, 0, this);
        }

        public void Interaction(GameObject interactivePlayer)
        {
            if (interactivePlayer.TryGetComponent(out Player player) && this.player == null)
            {
                SetItem(player);
            }
        }

        public void UseEffect()
        {
            MakeBullet();
        }


        public void ReLoad()
        {
            if (BulletCount == maxBullet)
                return;
            BulletCount += 1;
        }
    }
}
