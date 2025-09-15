using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class FinalMovement : MonoBehaviour
{
    // Token: 0x0600001E RID: 30 RVA: 0x000028CE File Offset: 0x00000ACE
    private void Start()
    {
        this.rb = base.GetComponent<Rigidbody2D>();
        this.anim = base.GetComponent<Animator>();
    }

    // Token: 0x0600001F RID: 31 RVA: 0x000028EC File Offset: 0x00000AEC
    private void Update()
    {
        bool flag = Input.GetButtonDown("Jump") && this.jumpCount > 0;
        if (flag)
        {
            this.jumpPressed = true;
        }
    }

    // Token: 0x06000020 RID: 32 RVA: 0x00002920 File Offset: 0x00000B20
    private void FixedUpdate()
    {
        this.isGround = Physics2D.OverlapCircle(this.groundCheck.position, 0.1f, this.ground);
        this.GroundMovement();
        this.Jump();
        this.SwitchAnim();
    }

    // Token: 0x06000021 RID: 33 RVA: 0x00002974 File Offset: 0x00000B74
    private void GroundMovement()
    {
        this.horizontalMove = Input.GetAxisRaw("Horizontal");
        this.rb.velocity = new Vector2(this.horizontalMove * this.speed, this.rb.velocity.y);
        bool flag = this.horizontalMove != 0f;
        if (flag)
        {
            base.transform.localScale = new Vector3(this.horizontalMove, 1f, 1f);
        }
    }

    // Token: 0x06000022 RID: 34 RVA: 0x000029F8 File Offset: 0x00000BF8
    private void Jump()
    {
        bool flag = this.isGround;
        if (flag)
        {
            this.jumpCount = 2;
            this.isJump = false;
        }
        bool flag2 = this.jumpPressed && this.isGround;
        if (flag2)
        {
            this.isJump = true;
            this.rb.velocity = new Vector2(this.rb.velocity.x, this.jumpForce);
            this.jumpCount--;
            this.jumpPressed = false;
        }
        else
        {
            bool flag3 = this.jumpPressed && this.jumpCount > 0 && this.isJump;
            if (flag3)
            {
                this.rb.velocity = new Vector2(this.rb.velocity.x, this.jumpForce);
                this.jumpCount--;
                this.jumpPressed = false;
            }
        }
    }

    // Token: 0x06000023 RID: 35 RVA: 0x00002AD8 File Offset: 0x00000CD8
    private void SwitchAnim()
    {
        this.anim.SetFloat("running", Mathf.Abs(this.rb.velocity.x));
        bool flag = this.isGround;
        if (flag)
        {
            this.anim.SetBool("falling", false);
        }
        else
        {
            bool flag2 = !this.isGround && this.rb.velocity.y > 0f;
            if (flag2)
            {
                this.anim.SetBool("jumping", true);
            }
            else
            {
                bool flag3 = this.rb.velocity.y < 0f;
                if (flag3)
                {
                    this.anim.SetBool("jumping", false);
                    this.anim.SetBool("falling", true);
                }
            }
        }
    }

    // Token: 0x04000027 RID: 39
    private Rigidbody2D rb;

    // Token: 0x04000028 RID: 40
    private Animator anim;

    // Token: 0x04000029 RID: 41
    public float speed;

    // Token: 0x0400002A RID: 42
    public float jumpForce;

    // Token: 0x0400002B RID: 43
    private float horizontalMove;

    // Token: 0x0400002C RID: 44
    public Transform groundCheck;

    // Token: 0x0400002D RID: 45
    public LayerMask ground;

    // Token: 0x0400002E RID: 46
    public bool isGround;

    // Token: 0x0400002F RID: 47
    public bool isJump;

    // Token: 0x04000030 RID: 48
    public bool isDashing;

    // Token: 0x04000031 RID: 49
    private bool jumpPressed;

    // Token: 0x04000032 RID: 50
    private int jumpCount;
}
