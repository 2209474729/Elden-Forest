using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Enemy : MonoBehaviour
{
    // Token: 0x06000007 RID: 7 RVA: 0x000020FC File Offset: 0x000002FC
    public void Start()
    {
        this.playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        this.Anim = base.transform.GetComponent<Animator>();
        this.deathAudio = base.GetComponent<AudioSource>();
        this.rb = base.transform.GetComponent<Rigidbody2D>();
    }

    // Token: 0x06000008 RID: 8 RVA: 0x00002150 File Offset: 0x00000350
    public void Update()
    {
        this.info = this.Anim.GetCurrentAnimatorStateInfo(0);
        bool flag = this.health <= 0;
        if (flag)
        {
            Object.Destroy(base.gameObject);
        }
        bool flag2 = this.isHit;
        if (flag2)
        {
            this.rb.velocity = this.direction * this.speed;
            bool flag3 = this.info.normalizedTime >= 0.6f;
            if (flag3)
            {
                this.isHit = false;
            }
        }
    }

    // Token: 0x06000009 RID: 9 RVA: 0x000021D9 File Offset: 0x000003D9
    public void TakeDamage(int damage)
    {
        this.health -= damage;
    }

    // Token: 0x0600000A RID: 10 RVA: 0x000021EC File Offset: 0x000003EC
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool flag = other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D";
        if (flag)
        {
            bool flag2 = this.playerHealth != null;
            if (flag2)
            {
                this.playerHealth.DamagePlayer(this.damage);
            }
        }
    }

    // Token: 0x0600000B RID: 11 RVA: 0x00002250 File Offset: 0x00000450
    public void Gethit(Vector2 direction)
    {
        base.transform.localScale = new Vector3(-direction.x, 1f, 1f);
        this.isHit = true;
        this.direction = direction;
        this.Anim.SetTrigger("Skeleton_hurt");
    }

    // Token: 0x04000003 RID: 3
    private PlayerHealth playerHealth;

    // Token: 0x04000004 RID: 4
    protected Animator Anim;

    // Token: 0x04000005 RID: 5
    protected AudioSource deathAudio;

    // Token: 0x04000006 RID: 6
    private Rigidbody2D rb;

    // Token: 0x04000007 RID: 7
    public int health;

    // Token: 0x04000008 RID: 8
    public int damage;

    // Token: 0x04000009 RID: 9
    public float speed;

    // Token: 0x0400000A RID: 10
    private bool isHit;

    // Token: 0x0400000B RID: 11
    private Vector2 direction;

    // Token: 0x0400000C RID: 12
    private AnimatorStateInfo info;

    // Token: 0x0400000D RID: 13
    private Animator hitAnimator;
}
