using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001A RID: 26
public class PlayerHealth : MonoBehaviour
{
    // Token: 0x06000072 RID: 114 RVA: 0x000043D0 File Offset: 0x000025D0
    private void Start()
    {
        this.Anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        this.CircleColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        this.CapsuleColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        this.rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        this.polygonCollider2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PolygonCollider2D>();
    }

    // Token: 0x06000073 RID: 115 RVA: 0x00004447 File Offset: 0x00002647
    private void FixedUpdate()
    {
        this.CheckPlayerIsDie();
    }

    // Token: 0x06000074 RID: 116 RVA: 0x00004451 File Offset: 0x00002651
    public void DamagePlayer(int damage)
    {
        this.health -= damage;
        SoundManager.instance.HurtAudio();
        this.polygonCollider2D.enabled = false;
        base.StartCoroutine(this.ShowPlayerHitBox());
    }

    // Token: 0x06000075 RID: 117 RVA: 0x00004487 File Offset: 0x00002687
    private IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(this.HitBoxCdTime);
        this.polygonCollider2D.enabled = true;
        yield break;
    }

    // Token: 0x06000076 RID: 118 RVA: 0x00004498 File Offset: 0x00002698
    public void CheckPlayerIsDie()
    {
        bool flag = this.health <= 0;
        if (flag)
        {
            this.Anim.Play("death");
            this.isDied = true;
            this.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.CircleColl.enabled = false;
            this.CapsuleColl.enabled = false;
            base.GetComponent<AudioSource>().enabled = false;
            base.Invoke("Restart", 5f);
        }
    }

    // Token: 0x06000077 RID: 119 RVA: 0x00004518 File Offset: 0x00002718
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.isDied = false;
    }

    // Token: 0x06000078 RID: 120 RVA: 0x00004540 File Offset: 0x00002740
    public void DeathAudio()
    {
        SoundManager.instance.DeathAudio();
    }

    // Token: 0x06000079 RID: 121 RVA: 0x0000454E File Offset: 0x0000274E
    public void DeathHurtAudio()
    {
        SoundManager.instance.DeathhurtAudio();
    }

    // Token: 0x04000089 RID: 137
    public int health;

    // Token: 0x0400008A RID: 138
    private Animator Anim;

    // Token: 0x0400008B RID: 139
    private Collider2D CircleColl;

    // Token: 0x0400008C RID: 140
    private Collider2D CapsuleColl;

    // Token: 0x0400008D RID: 141
    private Rigidbody2D rb;

    // Token: 0x0400008E RID: 142
    public bool isDied = false;

    // Token: 0x0400008F RID: 143
    public float HitBoxCdTime;

    // Token: 0x04000090 RID: 144
    public bool isHurt;

    // Token: 0x04000091 RID: 145
    private PolygonCollider2D polygonCollider2D;
}
