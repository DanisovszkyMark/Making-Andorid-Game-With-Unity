using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit == null || this.canDamage == false)
        {
            return;
        }

        hit.Damage();
        this.canDamage = false;
        StartCoroutine(resetDamage());
    }

    private IEnumerator resetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        this.canDamage = true;
    }
}
