using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class HitState : IState
{
    // Token: 0x06000049 RID: 73 RVA: 0x00003576 File Offset: 0x00001776
    public HitState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x0600004A RID: 74 RVA: 0x00003593 File Offset: 0x00001793
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_hurt");
    }

    // Token: 0x0600004B RID: 75 RVA: 0x000035AC File Offset: 0x000017AC
    public void OnUpdate()
    {
        this.info = this.parameter.animator.GetCurrentAnimatorStateInfo(0);
        bool flag = this.parameter.player.transform.position.x < this.manager.transform.position.x;
        if (flag)
        {
            this.parameter.direction = new Vector2(1f, 0f);
        }
        else
        {
            bool flag2 = this.parameter.player.transform.position.x > this.manager.transform.position.x;
            if (flag2)
            {
                this.parameter.direction = new Vector2(-1f, 0f);
            }
        }
        bool getdamage = this.parameter.getdamage;
        if (getdamage)
        {
            this.parameter.rb.velocity = this.parameter.direction * this.parameter.speed;
        }
        bool flag3 = this.parameter.health <= 0;
        if (flag3)
        {
            this.manager.TransitionState(StateType.Death);
        }
        else
        {
            bool flag4 = this.info.normalizedTime >= 0.95f;
            if (flag4)
            {
                this.parameter.target = GameObject.FindWithTag("Player").transform;
                this.manager.TransitionState(StateType.Chase);
            }
        }
    }

    // Token: 0x0600004C RID: 76 RVA: 0x0000371C File Offset: 0x0000191C
    public void OnExit()
    {
        this.parameter.getHit = false;
        this.parameter.getdamage = false;
    }

    // Token: 0x04000064 RID: 100
    private FSM manager;

    // Token: 0x04000065 RID: 101
    private Parameter parameter;

    // Token: 0x04000066 RID: 102
    private AnimatorStateInfo info;
}
