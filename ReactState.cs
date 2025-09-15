using System;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class ReactState : IState
{
    // Token: 0x06000041 RID: 65 RVA: 0x00003416 File Offset: 0x00001616
    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x06000042 RID: 66 RVA: 0x00003433 File Offset: 0x00001633
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_react");
    }

    // Token: 0x06000043 RID: 67 RVA: 0x0000344C File Offset: 0x0000164C
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

    // Token: 0x06000044 RID: 68 RVA: 0x000034B7 File Offset: 0x000016B7
    public void OnExit()
    {
    }

    // Token: 0x0400005E RID: 94
    private FSM manager;

    // Token: 0x0400005F RID: 95
    private Parameter parameter;

    // Token: 0x04000060 RID: 96
    private AnimatorStateInfo info;
}
