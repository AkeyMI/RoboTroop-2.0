using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionItem : MonoBehaviour
{
    public bool CanUseUlti { get; private set; }

    private MinionItemData itemData;

    private int currentReloadUlti;

    public void Init(MinionItemData data)
    {
        itemData = data;
    }


}
