using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class PatrolState : IState
{
    // Token: 0x06000039 RID: 57 RVA: 0x00003065 File Offset: 0x00001265
    public PatrolState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x0600003A RID: 58 RVA: 0x00003082 File Offset: 0x00001282
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_walk");
    }

    // Token: 0x0600003B RID: 59 RVA: 0x0000309C File Offset: 0x0000129C
    public void OnUpdate()
    {
        this.manager.FlipTo(this.parameter.patrolPoints[this.patrolPosition]);
        this.manager.transform.position = Vector2.MoveTowards(this.manager.transform.position, this.parameter.patrolPoints[this.patrolPosition].position, this.parameter.moveSpeed * Time.deltaTime);
        bool getHit = this.parameter.getHit;
        if (getHit)
        {
            this.manager.TransitionState(StateType.Hit);
        }
        bool flag = this.parameter.target != null && this.parameter.target.position.x >= this.parameter.chasePoint[0].position.x && this.parameter.target.position.x <= this.parameter.chasePoint[1].position.x;
        if (flag)
        {
            this.manager.TransitionState(StateType.React);
        }
        bool flag2 = Vector2.Distance(this.manager.transform.position, this.parameter.patrolPoints[this.patrolPosition].position) < 2f;
        if (flag2)
        {
            this.manager.TransitionState(StateType.Idle);
        }
    }

    // Token: 0x0600003C RID: 60 RVA: 0x0000321C File Offset: 0x0000141C
    public void OnExit()
    {
        this.patrolPosition++;
        bool flag = this.patrolPosition >= this.parameter.patrolPoints.Length;
        if (flag)
        {
            this.patrolPosition = 0;
        }
    }

    // Token: 0x04000059 RID: 89
    private FSM manager;

    // Token: 0x0400005A RID: 90
    private Parameter parameter;

    // Token: 0x0400005B RID: 91
    private int patrolPosition;
}
