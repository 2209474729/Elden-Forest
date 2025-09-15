using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class SoundManager : MonoBehaviour
{
    // Token: 0x06000080 RID: 128 RVA: 0x000045EC File Offset: 0x000027EC
    private void Awake()
    {
        SoundManager.instance = this;
    }

    // Token: 0x06000081 RID: 129 RVA: 0x000045F5 File Offset: 0x000027F5
    public void JumpAudio()
    {
        this.audioSource.clip = this.jumpAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000082 RID: 130 RVA: 0x00004616 File Offset: 0x00002816
    public void HurtAudio()
    {
        this.audioSource.clip = this.hurtAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000083 RID: 131 RVA: 0x00004637 File Offset: 0x00002837
    public void SoulAudio()
    {
        this.audioSource.clip = this.soulAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000084 RID: 132 RVA: 0x00004658 File Offset: 0x00002858
    public void RunAudio()
    {
        this.audioSource.clip = this.runAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000085 RID: 133 RVA: 0x00004679 File Offset: 0x00002879
    public void DeathAudio()
    {
        this.audioSource.clip = this.deathAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000086 RID: 134 RVA: 0x0000469A File Offset: 0x0000289A
    public void AttackAudio()
    {
        this.audioSource.clip = this.attackAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000087 RID: 135 RVA: 0x000046BB File Offset: 0x000028BB
    public void DeathhurtAudio()
    {
        this.audioSource.clip = this.deathhurtAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000088 RID: 136 RVA: 0x000046DC File Offset: 0x000028DC
    public void LightAttackAudio()
    {
        this.audioSource.clip = this.lightattackAudio;
        this.audioSource.Play();
    }

    // Token: 0x06000089 RID: 137 RVA: 0x000046FD File Offset: 0x000028FD
    public void LightAttack2Audio()
    {
        this.audioSource.clip = this.lightattack2Audio;
        this.audioSource.Play();
    }

    // Token: 0x0600008A RID: 138 RVA: 0x0000471E File Offset: 0x0000291E
    public void HeavyAttackAudio()
    {
        this.audioSource.clip = this.heavyattackAudio;
        this.audioSource.Play();
    }

    // Token: 0x04000095 RID: 149
    public static SoundManager instance;

    // Token: 0x04000096 RID: 150
    public AudioSource audioSource;

    // Token: 0x04000097 RID: 151
    [SerializeField]
    private AudioClip jumpAudio;

    // Token: 0x04000098 RID: 152
    [SerializeField]
    private AudioClip hurtAudio;

    // Token: 0x04000099 RID: 153
    [SerializeField]
    private AudioClip soulAudio;

    // Token: 0x0400009A RID: 154
    [SerializeField]
    private AudioClip runAudio;

    // Token: 0x0400009B RID: 155
    [SerializeField]
    private AudioClip deathAudio;

    // Token: 0x0400009C RID: 156
    [SerializeField]
    private AudioClip attackAudio;

    // Token: 0x0400009D RID: 157
    [SerializeField]
    private AudioClip deathhurtAudio;

    // Token: 0x0400009E RID: 158
    [SerializeField]
    private AudioClip lightattackAudio;

    // Token: 0x0400009F RID: 159
    [SerializeField]
    private AudioClip lightattack2Audio;

    // Token: 0x040000A0 RID: 160
    [SerializeField]
    private AudioClip heavyattackAudio;
}
