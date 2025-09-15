using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class Spike : MonoBehaviour
{
    // Token: 0x0600008C RID: 140 RVA: 0x00004748 File Offset: 0x00002948
    private void Start()
    {
        this.playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Token: 0x0600008D RID: 141 RVA: 0x00004760 File Offset: 0x00002960
    private void Update()
    {
    }

    // Token: 0x0600008E RID: 142 RVA: 0x00004764 File Offset: 0x00002964
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool flag = other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D";
        if (flag)
        {
        }
        bool flag2 = this.playerHealth != null;
        if (flag2)
        {
            this.playerHealth.DamagePlayer(this.damage);
        }
    }

    // Token: 0x040000A1 RID: 161
    public int damage;

    // Token: 0x040000A2 RID: 162
    public PlayerHealth playerHealth;
}
