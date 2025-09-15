using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
[Serializable]
public class Parameter
{
    // Token: 0x0400003B RID: 59
    public int health;

    // Token: 0x0400003C RID: 60
    public float moveSpeed;

    // Token: 0x0400003D RID: 61
    public float chaseSpeed;

    // Token: 0x0400003E RID: 62
    public float idleTime;

    // Token: 0x0400003F RID: 63
    public Transform[] patrolPoints;

    // Token: 0x04000040 RID: 64
    public Transform[] chasePoint;

    // Token: 0x04000041 RID: 65
    public Transform target;

    // Token: 0x04000042 RID: 66
    public LayerMask targetLayer;

    // Token: 0x04000043 RID: 67
    public Transform attackPoint;

    // Token: 0x04000044 RID: 68
    public float attackArea;

    // Token: 0x04000045 RID: 69
    public Animator animator;

    // Token: 0x04000046 RID: 70
    public bool getHit;

    // Token: 0x04000047 RID: 71
    public bool getdamage;

    // Token: 0x04000048 RID: 72
    public bool isAttack;

    // Token: 0x04000049 RID: 73
    public bool playerishurt;

    // Token: 0x0400004A RID: 74
    public bool playerisattack;

    // Token: 0x0400004B RID: 75
    public Rigidbody2D rb;

    // Token: 0x0400004C RID: 76
    public Vector2 direction;

    // Token: 0x0400004D RID: 77
    public float speed;

    // Token: 0x0400004E RID: 78
    public int damage;

    // Token: 0x0400004F RID: 79
    public GameObject player;

    // Token: 0x04000050 RID: 80
    public AudioSource walkAudio;

    // Token: 0x04000051 RID: 81
    public AudioSource attackAudio;

    // Token: 0x04000052 RID: 82
    public AudioSource hurtAudio;
}
