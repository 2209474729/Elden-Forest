using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Enemy_Frog : Enemy
{
    // Token: 0x06000011 RID: 17 RVA: 0x000023F0 File Offset: 0x000005F0
    public new void Start()
    {
        base.Start();
        this.rb = base.GetComponent<Rigidbody2D>();
        this.Coll = base.GetComponent<Collider2D>();
        base.transform.DetachChildren();
        this.leftx = this.leftpoint.position.x;
        this.rightx = this.rightpoint.position.x;
        Object.Destroy(this.leftpoint.gameObject);
        Object.Destroy(this.rightpoint.gameObject);
    }

    // Token: 0x06000012 RID: 18 RVA: 0x00002477 File Offset: 0x00000677
    public new void Update()
    {
        base.Update();
        this.SwitchAnim();
    }

    // Token: 0x06000013 RID: 19 RVA: 0x00002488 File Offset: 0x00000688
    public void Movement()
    {
        bool faceleft = this.Faceleft;
        if (faceleft)
        {
            bool flag = this.Coll.IsTouchingLayers(this.Ground);
            if (flag)
            {
                this.Anim.SetBool("jumping", true);
                this.rb.velocity = new Vector2(-this.Speed, this.JumpForce);
            }
            bool flag2 = base.transform.position.x < this.leftx;
            if (flag2)
            {
                this.rb.velocity = new Vector2(0f, 0f);
                base.transform.localScale = new Vector3(-1f, 1f, 1f);
                this.Faceleft = false;
            }
        }
        else
        {
            bool flag3 = this.Coll.IsTouchingLayers(this.Ground);
            if (flag3)
            {
                this.Anim.SetBool("jumping", true);
                this.rb.velocity = new Vector2(this.Speed, this.JumpForce);
            }
            bool flag4 = base.transform.position.x > this.rightx;
            if (flag4)
            {
                this.rb.velocity = new Vector2(0f, 0f);
                base.transform.localScale = new Vector3(1f, 1f, 1f);
                this.Faceleft = true;
            }
        }
    }

    // Token: 0x06000014 RID: 20 RVA: 0x00002608 File Offset: 0x00000808
    private void SwitchAnim()
    {
        bool @bool = this.Anim.GetBool("jumping");
        if (@bool)
        {
            bool flag = (double)this.rb.velocity.y < 0.1;
            if (flag)
            {
                this.Anim.SetBool("jumping", false);
                this.Anim.SetBool("falling", true);
            }
        }
        bool flag2 = this.Coll.IsTouchingLayers(this.Ground) && this.Anim.GetBool("falling");
        if (flag2)
        {
            this.Anim.SetBool("falling", false);
        }
    }

    // Token: 0x04000015 RID: 21
    private Rigidbody2D rb;

    // Token: 0x04000016 RID: 22
    private Collider2D Coll;

    // Token: 0x04000017 RID: 23
    public LayerMask Ground;

    // Token: 0x04000018 RID: 24
    public Transform leftpoint;

    // Token: 0x04000019 RID: 25
    public Transform rightpoint;

    // Token: 0x0400001A RID: 26
    public float Speed;

    // Token: 0x0400001B RID: 27
    public float JumpForce;

    // Token: 0x0400001C RID: 28
    private float leftx;

    // Token: 0x0400001D RID: 29
    private float rightx;

    // Token: 0x0400001E RID: 30
    private bool Faceleft = true;
}
