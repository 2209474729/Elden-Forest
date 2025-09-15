using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class Parallax : MonoBehaviour
{
    // Token: 0x0600005B RID: 91 RVA: 0x00003847 File Offset: 0x00001A47
    private void Start()
    {
        this.startPoint = base.transform.position.x;
    }

    // Token: 0x0600005C RID: 92 RVA: 0x00003860 File Offset: 0x00001A60
    private void Update()
    {
        base.transform.position = new Vector2(this.startPoint + this.Cam.position.x * this.moveRate, base.transform.position.y);
    }

    // Token: 0x0400006C RID: 108
    public Transform Cam;

    // Token: 0x0400006D RID: 109
    public float moveRate;

    // Token: 0x0400006E RID: 110
    private float startPoint;

    // Token: 0x0400006F RID: 111
    public AudioSource swordAudio;
}
