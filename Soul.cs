using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class Soul : MonoBehaviour
{
    // Token: 0x0600007E RID: 126 RVA: 0x000045C9 File Offset: 0x000027C9
    public void Death()
    {
        Object.FindObjectOfType<PlayerController>().SoulCount();
        Object.Destroy(base.gameObject);
    }
}
