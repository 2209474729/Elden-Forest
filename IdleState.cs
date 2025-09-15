using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class IdleState : IState
{
    // Token: 0x06000035 RID: 53 RVA: 0x00002F32 File Offset: 0x00001132
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x06000036 RID: 54 RVA: 0x00002F4F File Offset: 0x0000114F
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_idle");
    }

    // Token: 0x06000037 RID: 55 RVA: 0x00002F68 File Offset: 0x00001168
    public void OnUpdate()
    {
        this.timer += Time.deltaTime;
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
        bool flag2 = this.timer >= this.parameter.idleTime;
        if (flag2)
        {
            this.manager.TransitionState(StateType.Patrol);
        }
    }

    // Token: 0x06000038 RID: 56 RVA: 0x00003057 File Offset: 0x00001257
    public void OnExit()
    {
        this.timer = 0f;
    }

    // Token: 0x04000056 RID: 86
    private FSM manager;

    // Token: 0x04000057 RID: 87
    private Parameter parameter;

    // Token: 0x04000058 RID: 88
    private float timer;
}
