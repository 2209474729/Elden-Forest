using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class Enemy_Eye : Enemy
{
    // Token: 0x0600000D RID: 13 RVA: 0x000022A8 File Offset: 0x000004A8
    public new void Start()
    {
        base.Start();
        this.rb = base.GetComponent<Rigidbody2D>();
        this.TopY = this.top.position.y;
        this.BottomY = this.bottom.position.y;
        Object.Destroy(this.top.gameObject);
        Object.Destroy(this.bottom.gameObject);
    }

    // Token: 0x0600000E RID: 14 RVA: 0x00002317 File Offset: 0x00000517
    public new void Update()
    {
        base.Update();
        this.Movement();
    }

    // Token: 0x0600000F RID: 15 RVA: 0x00002328 File Offset: 0x00000528
    private void Movement()
    {
        bool flag = this.isUp;
        if (flag)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, this.Speed);
            bool flag2 = base.transform.position.y > this.TopY;
            if (flag2)
            {
                this.isUp = false;
            }
        }
        else
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, -this.Speed);
            bool flag3 = base.transform.position.y < this.BottomY;
            if (flag3)
            {
                this.isUp = true;
            }
        }
    }

    // Token: 0x0400000E RID: 14
    private Rigidbody2D rb;

    // Token: 0x0400000F RID: 15
    public Transform top;

    // Token: 0x04000010 RID: 16
    public Transform bottom;

    // Token: 0x04000011 RID: 17
    public float Speed;

    // Token: 0x04000012 RID: 18
    public float TopY;

    // Token: 0x04000013 RID: 19
    public float BottomY;

    // Token: 0x04000014 RID: 20
    private bool isUp = true;
}
