using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000020 RID: 32
public class ChatController : MonoBehaviour
{
    // Token: 0x06000093 RID: 147 RVA: 0x000047DF File Offset: 0x000029DF
    private void OnEnable()
    {
        this.ChatInputField.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
    }

    // Token: 0x06000094 RID: 148 RVA: 0x000047FF File Offset: 0x000029FF
    private void OnDisable()
    {
        this.ChatInputField.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
    }

    // Token: 0x06000095 RID: 149 RVA: 0x00004820 File Offset: 0x00002A20
    private void AddToChatOutput(string newText)
    {
        this.ChatInputField.text = string.Empty;
        DateTime timeNow = DateTime.Now;
        string formattedInput = string.Concat(new string[]
        {
            "[<#FFFF80>",
            timeNow.Hour.ToString("d2"),
            ":",
            timeNow.Minute.ToString("d2"),
            ":",
            timeNow.Second.ToString("d2"),
            "</color>] ",
            newText
        });
        bool flag = this.ChatDisplayOutput != null;
        if (flag)
        {
            bool flag2 = this.ChatDisplayOutput.text == string.Empty;
            if (flag2)
            {
                this.ChatDisplayOutput.text = formattedInput;
            }
            else
            {
                TMP_Text chatDisplayOutput = this.ChatDisplayOutput;
                chatDisplayOutput.text = chatDisplayOutput.text + "\n" + formattedInput;
            }
        }
        this.ChatInputField.ActivateInputField();
        this.ChatScrollbar.value = 0f;
    }

    // Token: 0x040000A3 RID: 163
    public TMP_InputField ChatInputField;

    // Token: 0x040000A4 RID: 164
    public TMP_Text ChatDisplayOutput;

    // Token: 0x040000A5 RID: 165
    public Scrollbar ChatScrollbar;
}
