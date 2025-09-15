using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class Enemy_Mushroom : Enemy
{
	// Token: 0x06000016 RID: 22 RVA: 0x000026C8 File Offset: 0x000008C8
	private new void Start()
	{
		base.Start();
		this.rb2d = base.GetComponent<Rigidbody2D>();
		base.transform.DetachChildren();
		this.leftx = this.leftpoint.position.x;
		this.rightx = this.rightpoint.position.x;
		Object.Destroy(this.leftpoint.gameObject);
		Object.Destroy(this.rightpoint.gameObject);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002743 File Offset: 0x00000943
	private new void Update()
	{
		this.Movement();
		base.Update();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002754 File Offset: 0x00000954
	private void FixedUpdate()
	{
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002758 File Offset: 0x00000958
	public void Movement()
	{
		bool faceleft = this.Faceleft;
		if (faceleft)
		{
			this.rb2d.velocity = new Vector2(-this.MoveSpeed, this.rb2d.velocity.y);
			bool flag = base.transform.position.x < this.leftx;
			if (flag)
			{
				base.transform.localScale = new Vector3(-1f, 1f, 1f);
				this.Faceleft = false;
			}
		}
		else
		{
			this.rb2d.velocity = new Vector2(this.MoveSpeed, this.rb2d.velocity.y);
			bool flag2 = base.transform.position.x > this.rightx;
			if (flag2)
			{
				base.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Faceleft = true;
			}
		}
	}

	// Token: 0x0400001F RID: 31
	public Rigidbody2D rb2d;

	// Token: 0x04000020 RID: 32
	public float MoveSpeed;

	// Token: 0x04000021 RID: 33
	public bool Faceleft = true;

	// Token: 0x04000022 RID: 34
	public Transform leftpoint;

	// Token: 0x04000023 RID: 35
	public Transform rightpoint;

	// Token: 0x04000024 RID: 36
	public float leftx;

	// Token: 0x04000025 RID: 37
	public float rightx;
}
