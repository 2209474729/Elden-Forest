using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class EnvMapAnimator : MonoBehaviour
{
    // Token: 0x06000099 RID: 153 RVA: 0x000049BE File Offset: 0x00002BBE
    private void Awake()
    {
        this.m_textMeshPro = base.GetComponent<TMP_Text>();
        this.m_material = this.m_textMeshPro.fontSharedMaterial;
    }

    // Token: 0x0600009A RID: 154 RVA: 0x000049DE File Offset: 0x00002BDE
    private IEnumerator Start()
    {
        Matrix4x4 matrix = default(Matrix4x4);
        for (; ; )
        {
            matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
            this.m_material.SetMatrix("_EnvMatrix", matrix);
            yield return null;
        }
        yield break;
    }

    // Token: 0x040000A9 RID: 169
    public Vector3 RotationSpeeds;

    // Token: 0x040000AA RID: 170
    private TMP_Text m_textMeshPro;

    // Token: 0x040000AB RID: 171
    private Material m_material;
}
