using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class Portal : MonoBehaviour
{
    // Token: 0x0600007B RID: 123 RVA: 0x0000456C File Offset: 0x0000276C
    private void Start()
    {
        this.playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Token: 0x0600007C RID: 124 RVA: 0x00004584 File Offset: 0x00002784
    private void OnTriggerStay2D(Collider2D collision)
    {
        bool keyDown = Input.GetKeyDown(KeyCode.E);
        if (keyDown)
        {
            this.playerPos.transform.position = this.goToPos.transform.position;
        }
    }

    // Token: 0x04000092 RID: 146
    public Transform goToPos;

    // Token: 0x04000093 RID: 147
    private Transform playerPos;

    // Token: 0x04000094 RID: 148
    public AudioSource doorAudio;
}
