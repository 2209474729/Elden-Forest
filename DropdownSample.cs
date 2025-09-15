using System;
using TMPro;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class DropdownSample : MonoBehaviour
{
    // Token: 0x06000097 RID: 151 RVA: 0x0000493C File Offset: 0x00002B3C
    public void OnButtonClick()
    {
        this.text.text = ((this.dropdownWithPlaceholder.value > -1) ? ("Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString()) : "Error: Please make a selection");
    }

    // Token: 0x040000A6 RID: 166
    [SerializeField]
    private TextMeshProUGUI text = null;

    // Token: 0x040000A7 RID: 167
    [SerializeField]
    private TMP_Dropdown dropdownWithoutPlaceholder = null;

    // Token: 0x040000A8 RID: 168
    [SerializeField]
    private TMP_Dropdown dropdownWithPlaceholder = null;
}
