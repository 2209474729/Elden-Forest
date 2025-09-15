using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class AttackArea : MonoBehaviour
{
    // Token: 0x06000001 RID: 1
    private void Start()
    {
        this.damage = GameObject.Find("Enemy").GetComponent<FSM>().parameter.damage;
    }

    // Token: 0x06000002 RID: 2
    private void Update()
    {
    }

    // Token: 0x06000003 RID: 3
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().DamagePlayer(this.damage);
        }
    }

    // Token: 0x04000001 RID: 1
    public int damage;
}
