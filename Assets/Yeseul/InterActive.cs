using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Yeseul
{
    public interface IInteractive
    {
        void Interaction();
    }

    public class InterActive : MonoBehaviour
    {
        public float range = 2f; // ��ȣ�ۿ� ��� Ž������

        GameObject FindNearestObj(Collider[] cols) // ����� �������̽� ������� üũ 
        {
            GameObject nearestObj = null;
            float leastDistance = Mathf.Infinity;

            foreach (Collider col in cols)
            {
                IInteractive interactive = col.GetComponent<IInteractive>();    //IInteractive �������̽��� �������� �Ÿ�üũ
                if (interactive != null)
                {
                    float distance = Vector3.Distance(transform.position, col.transform.position);
                    if (distance < leastDistance)
                    {
                        leastDistance = distance;
                        nearestObj = col.gameObject;

                    }
                }
            }

            return nearestObj;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, range);

                GameObject nearObj = FindNearestObj(cols);

                if (nearObj != null)
                {
                    IInteractive interactiveObj = nearObj.GetComponent<IInteractive>();
                    interactiveObj?.Interaction();
                }
            }
        }

    }
}
