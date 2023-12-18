using Jinho;
using System.Collections;
using UnityEngine;

namespace Hojun
{

    public class HealKit : MonoBehaviour, IUseable
    {

        Animator animator;
        IEnumerator checkMouseCo;


        public ItemType ItemType 
        {
            get => itemType;
            set
            {
                itemType = value;
            }
        }
        ItemType itemType;

        public Player Player 
        { 
            get => player;
            set 
            {
                player = value;
                animator = player.animator;
            }
        }
        public Player player;

        public void Awake()
        {
            itemType = Jinho.ItemType.HealKit;
        }

        // �� ��
        public Jinho.IAttackStrategy AttackStrategy 
        { 
            get => null;
            set => throw new System.NotImplementedException();
        }

        // �Ⱦ�
        public void SetItem(Player player)
        {
            throw new System.NotImplementedException();
        }


        public void Use()
        {
            StartCoroutine( CheckMouse() );
        }

        IEnumerator CheckMouse()
        {
            while (true) 
            {
                yield return null;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    player.animator.SetBool("HealKit", true);
                    Debug.Log("??");
                    continue;
                }
                player.animator.SetBool("HealKit", false);
                break;
            }

        }


        public void UseEffect()
        {
            player.Hp += 30;
            Debug.Log("healkit ����ϰ� ���ְ� �س��� player �ȿ� �ش� healkit�� �ڽ����� �ִٸ�" +
                "�÷��̾� ���� ������ ���� Ȯ�� �� ��");
            Destroy(this.gameObject);
            player.animator.SetBool("HealKit", false);
            player.WeaponIndex = 0;

        }
    }
}