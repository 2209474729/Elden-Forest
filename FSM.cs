using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class FSM : MonoBehaviour
{
    // Token: 0x06000026 RID: 38 RVA: 0x00002BBC File Offset: 0x00000DBC
    private void Start()
    {
        this.states.Add(StateType.Idle, new IdleState(this));
        this.states.Add(StateType.Patrol, new PatrolState(this));
        this.states.Add(StateType.Chase, new ChaseState(this));
        this.states.Add(StateType.React, new ReactState(this));
        this.states.Add(StateType.Attack, new AttackState(this));
        this.states.Add(StateType.Hit, new HitState(this));
        this.states.Add(StateType.Death, new DeathState(this));
        this.TransitionState(StateType.Idle);
        this.parameter.animator = base.GetComponent<Animator>();
        this.parameter.rb = base.GetComponent<Rigidbody2D>();
        this.parameter.player = GameObject.FindWithTag("Player");
        this.parameter.playerishurt = GameObject.Find("Player").GetComponent<PlayerController>().isHurt;
        this.parameter.playerisattack = GameObject.Find("Player").GetComponent<PlayerController>().isAttack;
    }

    // Token: 0x06000027 RID: 39 RVA: 0x00002CCC File Offset: 0x00000ECC
    private void Update()
    {
        this.currentState.OnUpdate();
        bool getdamage = this.parameter.getdamage;
        if (getdamage)
        {
            this.parameter.getHit = true;
        }
    }

    // Token: 0x06000028 RID: 40 RVA: 0x00002D04 File Offset: 0x00000F04
    public void TransitionState(StateType type)
    {
        bool flag = this.currentState != null;
        if (flag)
        {
            this.currentState.OnExit();
        }
        this.currentState = this.states[type];
        this.currentState.OnEnter();
    }

    // Token: 0x06000029 RID: 41 RVA: 0x00002D4C File Offset: 0x00000F4C
    public void FlipTo(Transform target)
    {
        bool flag = target != null;
        if (flag)
        {
            bool flag2 = base.transform.position.x > target.position.x;
            if (flag2)
            {
                base.transform.localScale = new Vector3(-0.7f, 0.7f, 1f);
            }
            else
            {
                bool flag3 = base.transform.position.x < target.position.x;
                if (flag3)
                {
                    base.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                }
            }
        }
    }

    // Token: 0x0600002A RID: 42 RVA: 0x00002DF4 File Offset: 0x00000FF4
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool flag = other.CompareTag("Player") || this.parameter.playerishurt || this.parameter.playerisattack;
        if (flag)
        {
            this.parameter.target = other.transform;
        }
    }

    // Token: 0x0600002B RID: 43 RVA: 0x00002E44 File Offset: 0x00001044
    private void OnTriggerExit2D(Collider2D other)
    {
        bool flag = other.CompareTag("Player") && !this.parameter.isAttack && !this.parameter.playerishurt && !this.parameter.playerisattack;
        if (flag)
        {
            this.parameter.target = null;
        }
    }

    // Token: 0x0600002C RID: 44 RVA: 0x00002E9C File Offset: 0x0000109C
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.parameter.attackPoint.position, this.parameter.attackArea);
    }

    // Token: 0x0600002D RID: 45 RVA: 0x00002EC0 File Offset: 0x000010C0
    public void TakeDamage(int damage)
    {
        this.parameter.health -= damage;
        this.parameter.getdamage = true;
    }

    // Token: 0x0600002E RID: 46 RVA: 0x00002EE2 File Offset: 0x000010E2
    public void WalkAudio()
    {
        this.parameter.walkAudio.Play();
    }

    // Token: 0x0600002F RID: 47 RVA: 0x00002EF6 File Offset: 0x000010F6
    public void AttackAudio()
    {
        this.parameter.attackAudio.Play();
    }

    // Token: 0x06000030 RID: 48 RVA: 0x00002F0A File Offset: 0x0000110A
    public void HurtAudio()
    {
        this.parameter.hurtAudio.Play();
    }

    // Token: 0x04000053 RID: 83
    public Parameter parameter;

    // Token: 0x04000054 RID: 84
    private IState currentState;

    // Token: 0x04000055 RID: 85
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
}
