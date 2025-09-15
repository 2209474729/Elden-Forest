using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class AttackState : IState
{
    // Token: 0x06000045 RID: 69 RVA: 0x000034BA File Offset: 0x000016BA
    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x06000046 RID: 70 RVA: 0x000034D7 File Offset: 0x000016D7
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_attack");
        this.parameter.isAttack = true;
    }

    // Token: 0x06000047 RID: 71 RVA: 0x000034FC File Offset: 0x000016FC
    public void OnUpdate()
    {
        this.info = this.parameter.animator.GetCurrentAnimatorStateInfo(0);
        bool getHit = this.parameter.getHit;
        if (getHit)
        {
            this.manager.TransitionState(StateType.Hit);
        }
        bool flag = this.info.normalizedTime >= 0.95f;
        if (flag)
        {
            this.manager.TransitionState(StateType.Chase);
        }
    }

    // Token: 0x06000048 RID: 72 RVA: 0x00003567 File Offset: 0x00001767
    public void OnExit()
    {
        this.parameter.isAttack = false;
    }

    // Token: 0x04000061 RID: 97
    private FSM manager;

    // Token: 0x04000062 RID: 98
    private Parameter parameter;

    // Token: 0x04000063 RID: 99
    private AnimatorStateInfo info;
}