using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class EnterDialog : MonoBehaviour
{
    // Token: 0x0600001B RID: 27 RVA: 0x00002860 File Offset: 0x00000A60
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool flag = collision.tag == "Player";
        if (flag)
        {
            this.enterDialog.SetActive(true);
        }
    }

    // Token: 0x0600001C RID: 28 RVA: 0x00002894 File Offset: 0x00000A94
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool flag = collision.tag == "Player";
        if (flag)
        {
            this.enterDialog.SetActive(false);
        }
    }

    // Token: 0x04000026 RID: 38
    public GameObject enterDialog;
}
