using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class CameraControl : MonoBehaviour
{
    // Token: 0x06000005 RID: 5 RVA: 0x000020B7 File Offset: 0x000002B7
    private void Update()
    {
        base.transform.position = new Vector3(this.player.position.x, this.player.position.y, -10f);
    }

    // Token: 0x04000002 RID: 2
    public Transform player;
}
