using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class ChaseState : IState
{
    // Token: 0x0600003D RID: 61 RVA: 0x0000325D File Offset: 0x0000145D
    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x0600003E RID: 62 RVA: 0x0000327A File Offset: 0x0000147A
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_walk");
    }

    // Token: 0x0600003F RID: 63 RVA: 0x00003294 File Offset: 0x00001494
    public void OnUpdate()
    {
        this.manager.FlipTo(this.parameter.target);
        bool getHit = this.parameter.getHit;
        if (getHit)
        {
            this.manager.TransitionState(StateType.Hit);
        }
        bool flag = this.parameter.target;
        if (flag)
        {
            this.manager.transform.position = Vector2.MoveTowards(this.manager.transform.position, this.parameter.target.position, this.parameter.chaseSpeed * Time.deltaTime);
        }
        bool flag2 = this.parameter.target == null || this.manager.transform.position.x < this.parameter.chasePoint[0].position.x || this.manager.transform.position.x > this.parameter.chasePoint[1].position.x;
        if (flag2)
        {
            this.manager.TransitionState(StateType.Idle);
        }
        bool flag3 = Physics2D.OverlapCircle(this.parameter.attackPoint.position, this.parameter.attackArea, this.parameter.targetLayer);
        if (flag3)
        {
            this.manager.TransitionState(StateType.Attack);
        }
    }

    // Token: 0x06000040 RID: 64 RVA: 0x00003413 File Offset: 0x00001613
    public void OnExit()
    {
    }

    // Token: 0x0400005C RID: 92
    private FSM manager;

    // Token: 0x0400005D RID: 93
    private Parameter parameter;
}
