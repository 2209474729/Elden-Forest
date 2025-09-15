using System;

// Token: 0x02000014 RID: 20
public class DeathState : IState
{
    // Token: 0x0600004D RID: 77 RVA: 0x00003737 File Offset: 0x00001937
    public DeathState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    // Token: 0x0600004E RID: 78 RVA: 0x00003754 File Offset: 0x00001954
    public void OnEnter()
    {
        this.parameter.animator.Play("Skeleton_die");
    }

    // Token: 0x0600004F RID: 79 RVA: 0x0000376D File Offset: 0x0000196D
    public void OnUpdate()
    {
    }

    // Token: 0x06000050 RID: 80 RVA: 0x00003770 File Offset: 0x00001970
    public void OnExit()
    {
    }

    // Token: 0x04000067 RID: 103
    private FSM manager;

    // Token: 0x04000068 RID: 104
    private Parameter parameter;
}
