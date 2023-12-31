using UnityEngine;

public class Explosion : MonoBehaviour
{
    float blastDamage;
    float blastRadius;

    float timer = 0;

    public void Init(float blastDamage, float blastRadius)
    {
        this.blastDamage = blastDamage;
        this.blastRadius = blastRadius;
        transform.localScale = Vector3.one * this.blastRadius;// set explosion size
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(blastDamage);
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.GetComponentInParent<Player>().TakeDamage(blastDamage);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= .33f) Destroy(gameObject);
    }// dissapear after 0.33 seconds
}