using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

namespace Jaeyoung
{
    // ���� �߻��� ����üũ
    public class SoundComponent : MonoBehaviour
    {
        public float soundAreaSize;
        public float time;

        private void Start()
        {
            StartCoroutine(Boom());
        }

        IEnumerator Boom()
        {
            while (true)
            {
                Collider[] coll = Physics.OverlapSphere(transform.position, soundAreaSize);

                if (coll.Length > 0)
                {
                    foreach (Collider zombie in coll)
                    {
                        if (zombie.TryGetComponent<TestTarget>(out TestTarget zom))
                        {
                            if (zom.HearStrategy == null)
                                continue;

                            // zom.hearValue�� ����.
                        }
                    }

                    yield return new WaitForSeconds(time);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, soundAreaSize);
        }
    }
}