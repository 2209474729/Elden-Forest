using System;

// Token: 0x0200000D RID: 13
public interface IState
{
    // Token: 0x06000032 RID: 50
    void OnEnter();

    // Token: 0x06000033 RID: 51
    void OnUpdate();

    // Token: 0x06000034 RID: 52
    void OnExit();
}
