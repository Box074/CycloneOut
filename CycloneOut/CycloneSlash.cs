using System.Collections;
using UnityEngine;

namespace CycloneOut
{
    public class CycloneSlash : MonoBehaviour
    {
        bool right = false;
        void Awake()
        {

            right = HeroController.instance.cState.facingRight;
            StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            float x = 0;
            if (right)
            {
                x = 0.5f;
            }
            else
            {
                x = -0.5f;
            }
            for(int i = 0; i < 90; i++)
            {
                transform.SetPositionX(transform.position.x + x);
                transform.SetPositionY(transform.position.y + 0.08f);
                yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(0.5f);
            for(int i = 0; i < 900; i++)
            {
                transform.SetPositionX(transform.position.x - x);
                transform.SetPositionY(transform.position.y + 0.03f);
                yield return new WaitForSeconds(0.03f);
            }
            Destroy(gameObject);
        }
    }
}