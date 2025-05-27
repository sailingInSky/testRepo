using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCObject : InteractableObject
{
    public string NpcName;
    public string[] contentList;

    protected override void Interact()
    {
        DialogUI.Instance.Show(NpcName, contentList);
    }

}
