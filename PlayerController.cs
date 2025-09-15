using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000019 RID: 25
public class PlayerController : MonoBehaviour
{
    // Token: 0x06000062 RID: 98 RVA: 0x000038CD File Offset: 0x00001ACD
    public void Start()
    {
        this.rb = base.GetComponent<Rigidbody2D>();
        this.anim = base.GetComponent<Animator>();
        this.Enemy = GameObject.FindWithTag("Enemy");
    }

    // Token: 0x06000063 RID: 99 RVA: 0x000038F8 File Offset: 0x00001AF8
    public void FixedUpdate()
    {
        this.die = GameObject.Find("Player").GetComponent<PlayerHealth>().isDied;
        bool flag = !this.isHurt & !this.die;
        if (flag)
        {
            this.Movement();
        }
        this.SwitchAnim();
    }

    // Token: 0x06000064 RID: 100 RVA: 0x00003947 File Offset: 0x00001B47
    public void Update()
    {
        this.Attack();
        this.Jump();
        this.Crouch();
        this.SoulNum.text = this.Soul.ToString();
    }

    // Token: 0x06000065 RID: 101 RVA: 0x00003978 File Offset: 0x00001B78
    public void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        bool flag = !this.isAttack;
        if (flag)
        {
            bool flag2 = horizontalmove != 0f;
            if (flag2)
            {
                this.rb.velocity = new Vector2(horizontalmove * this.speed * Time.fixedDeltaTime, this.rb.velocity.y);
                this.anim.SetFloat("running", Mathf.Abs(facedirection));
            }
        }
        else
        {
            bool flag3 = this.attackType == "Light";
            if (flag3)
            {
                this.rb.velocity = new Vector2(base.transform.localScale.x * this.lightSpeed, this.rb.velocity.y);
            }
            else
            {
                bool flag4 = this.attackType == "Heavy";
                if (flag4)
                {
                    this.rb.velocity = new Vector2(base.transform.localScale.x * this.heavySpeed, this.rb.velocity.y);
                }
            }
        }
        bool flag5 = facedirection != 0f;
        if (flag5)
        {
            base.transform.localScale = new Vector3(facedirection, 1f, 1f);
        }
        bool flag6 = this.coll.IsTouchingLayers(this.ground);
        if (flag6)
        {
            bool flag7 = !this.anim.GetBool("crouching");
            if (flag7)
            {
                bool flag8 = Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A);
                if (flag8)
                {
                    this.rb.constraints = (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
                    bool flag9 = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
                    if (flag9)
                    {
                        this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }
    }

    // Token: 0x06000066 RID: 102 RVA: 0x00003B64 File Offset: 0x00001D64
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool flag = other.tag == "Collection";
        if (flag)
        {
            other.GetComponent<Animator>().Play("isGot");
            SoundManager.instance.SoulAudio();
        }
        bool flag2 = other.tag == "DeadLine";
        if (flag2)
        {
            SoundManager.instance.DeathAudio();
            this.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            base.GetComponent<AudioSource>().enabled = false;
            base.Invoke("Restart", 5f);
        }
        bool flag3 = other.gameObject.CompareTag("Enemy");
        if (flag3)
        {
            other.GetComponent<FSM>().TakeDamage(this.damage);
        }
        bool flag4 = other.gameObject.tag == "AttackArea";
        if (flag4)
        {
            bool flag5 = base.transform.position.x < this.Enemy.transform.position.x;
            if (flag5)
            {
                this.rb.velocity = new Vector2(-7f, this.rb.velocity.y);
                SoundManager.instance.HurtAudio();
                this.isHurt = true;
            }
            bool flag6 = base.transform.position.x > this.Enemy.transform.position.x;
            if (flag6)
            {
                this.rb.velocity = new Vector2(7f, this.rb.velocity.y);
                SoundManager.instance.HurtAudio();
                this.isHurt = true;
            }
        }
        bool flag7 = other.gameObject.CompareTag("Spike");
        if (flag7)
        {
            this.isHurt = true;
        }
    }

    // Token: 0x06000067 RID: 103 RVA: 0x00003D24 File Offset: 0x00001F24
    private void Crouch()
    {
        bool flag = this.coll.IsTouchingLayers(this.ground) && !this.isHurt;
        if (flag)
        {
            bool flag2 = !Physics2D.OverlapCircle(this.CellingCheck.position, 0.2f, this.Top);
            if (flag2)
            {
                bool button = Input.GetButton("Crouch");
                if (button)
                {
                    this.anim.SetFloat("running", 0f);
                    this.anim.SetBool("crouching", true);
                    this.DisColl.enabled = false;
                    this.rb.constraints = (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
                }
                else
                {
                    this.anim.SetBool("crouching", false);
                    this.DisColl.enabled = true;
                    this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    }

    // Token: 0x06000068 RID: 104 RVA: 0x00003E18 File Offset: 0x00002018
    private void Jump()
    {
        bool flag = Input.GetButtonDown("Jump") && this.coll.IsTouchingLayers(this.ground) && !this.anim.GetBool("crouching") && !this.isHurt;
        if (flag)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, this.jumpforce * Time.fixedDeltaTime);
            SoundManager.instance.JumpAudio();
            this.anim.SetBool("jumping", true);
        }
        bool flag2 = this.rb.velocity.y < 0f;
        if (flag2)
        {
            this.rb.velocity += Vector2.up * Physics2D.gravity.y * (this.fallMultiplier - 1f) * Time.deltaTime;
        }
        else
        {
            bool flag3 = this.rb.velocity.y > 0f && !Input.GetButton("Jump");
            if (flag3)
            {
                this.rb.velocity += Vector2.up * Physics2D.gravity.y * (this.lowJumpMultiplier - 1f) * Time.deltaTime;
            }
        }
    }

    // Token: 0x06000069 RID: 105 RVA: 0x00003F94 File Offset: 0x00002194
    public void runningSound()
    {
        bool flag = this.coll.IsTouchingLayers(this.ground);
        if (flag)
        {
            SoundManager.instance.RunAudio();
        }
    }

    // Token: 0x0600006A RID: 106 RVA: 0x00003FCC File Offset: 0x000021CC
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Token: 0x0600006B RID: 107 RVA: 0x00003FED File Offset: 0x000021ED
    public void SoulCount()
    {
        this.Soul++;
    }

    // Token: 0x0600006C RID: 108 RVA: 0x00004000 File Offset: 0x00002200
    public void SwitchAnim()
    {
        bool flag = this.rb.velocity.y < 0.1f && !this.coll.IsTouchingLayers(this.ground);
        if (flag)
        {
            this.anim.SetBool("falling", true);
        }
        bool @bool = this.anim.GetBool("jumping");
        if (@bool)
        {
            bool flag2 = this.rb.velocity.y < 0f;
            if (flag2)
            {
                this.anim.SetBool("jumping", false);
                this.anim.SetBool("falling", true);
            }
        }
        else
        {
            bool flag3 = this.isHurt;
            if (flag3)
            {
                this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                this.anim.SetBool("crouching", false);
                this.anim.SetBool("falling", false);
                this.anim.SetBool("jumping", false);
                this.anim.SetBool("hurt", true);
                this.anim.SetFloat("running", 0f);
                this.anim.SetTrigger("hurting");
                bool flag4 = Mathf.Abs(this.rb.velocity.x) < 0.1f;
                if (flag4)
                {
                    this.anim.SetBool("hurt", false);
                    this.isHurt = false;
                    this.rb.velocity = new Vector2(0f, 0f);
                }
            }
            else
            {
                bool flag5 = this.coll.IsTouchingLayers(this.ground);
                if (flag5)
                {
                    this.anim.SetBool("falling", false);
                }
            }
        }
    }

    // Token: 0x0600006D RID: 109 RVA: 0x000041CC File Offset: 0x000023CC
    public void Attack()
    {
        bool flag = Input.GetKeyDown(KeyCode.J) && !this.isAttack;
        if (flag)
        {
            this.damage = 1;
            this.isAttack = true;
            this.attackType = "Light";
            this.comboStep++;
            bool flag2 = this.comboStep > 2;
            if (flag2)
            {
                this.comboStep = 1;
            }
            this.timer = this.interval;
            this.anim.SetTrigger("LightAttack");
            this.anim.SetInteger("ComboStep", this.comboStep);
            this.anim.SetFloat("running", 0f);
        }
        bool flag3 = Input.GetKeyDown(KeyCode.K) && !this.isAttack;
        if (flag3)
        {
            SoundManager.instance.HeavyAttackAudio();
            this.damage = 3;
            this.isAttack = true;
            this.attackType = "Heavy";
            this.comboStep++;
            bool flag4 = this.comboStep > 2;
            if (flag4)
            {
                this.comboStep = 1;
            }
            this.timer = this.interval;
            this.anim.SetTrigger("HeavyAttack");
            this.anim.SetInteger("ComboStep", this.comboStep);
            this.anim.SetFloat("running", 0f);
        }
        bool flag5 = this.timer != 0f;
        if (flag5)
        {
            this.timer -= Time.deltaTime;
            bool flag6 = this.timer <= 0f;
            if (flag6)
            {
                this.timer = 0f;
                this.comboStep = 0;
            }
        }
    }

    // Token: 0x0600006E RID: 110 RVA: 0x0000437F File Offset: 0x0000257F
    private void AttackOver()
    {
        this.isAttack = false;
    }

    // Token: 0x0600006F RID: 111 RVA: 0x00004389 File Offset: 0x00002589
    public void LightAttack1()
    {
        SoundManager.instance.LightAttackAudio();
    }

    // Token: 0x06000070 RID: 112 RVA: 0x00004397 File Offset: 0x00002597
    public void LightAttack2()
    {
        SoundManager.instance.LightAttack2Audio();
    }

    // Token: 0x04000070 RID: 112
    [Header("预设")]
    public Rigidbody2D rb;

    // Token: 0x04000071 RID: 113
    public Animator anim;

    // Token: 0x04000072 RID: 114
    public LayerMask ground;

    // Token: 0x04000073 RID: 115
    public LayerMask Top;

    // Token: 0x04000074 RID: 116
    public Text SoulNum;

    // Token: 0x04000075 RID: 117
    public Collider2D coll;

    // Token: 0x04000076 RID: 118
    public Collider2D DisColl;

    // Token: 0x04000077 RID: 119
    public Transform CellingCheck;

    // Token: 0x04000078 RID: 120
    [Space]
    [Header("补偿速度")]
    public float lightSpeed;

    // Token: 0x04000079 RID: 121
    public float heavySpeed;

    // Token: 0x0400007A RID: 122
    [Space]
    [Header("变量")]
    public bool die;

    // Token: 0x0400007B RID: 123
    public float speed;

    // Token: 0x0400007C RID: 124
    public float jumpforce;

    // Token: 0x0400007D RID: 125
    public int Soul;

    // Token: 0x0400007E RID: 126
    public float fallMultiplier = 2.5f;

    // Token: 0x0400007F RID: 127
    public float lowJumpMultiplier = 2f;

    // Token: 0x04000080 RID: 128
    public bool hurt;

    // Token: 0x04000081 RID: 129
    private int comboStep;

    // Token: 0x04000082 RID: 130
    public float interval = 2f;

    // Token: 0x04000083 RID: 131
    private float timer;

    // Token: 0x04000084 RID: 132
    public bool isAttack;

    // Token: 0x04000085 RID: 133
    private string attackType;

    // Token: 0x04000086 RID: 134
    public bool isHurt;

    // Token: 0x04000087 RID: 135
    public int damage;

    // Token: 0x04000088 RID: 136
    public GameObject Enemy;
}
