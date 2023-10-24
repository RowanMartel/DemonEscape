using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float blastDamage;
    float blastRadius;

    public void Init(float blastDamage, float blastRadius)
    {
        this.blastDamage = blastDamage;
        this.blastRadius = blastRadius;
        transform.localScale = Vector3.one * this.blastRadius / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(blastDamage);
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.GetComponent<Player>().TakeDamage(blastDamage);
    }
}