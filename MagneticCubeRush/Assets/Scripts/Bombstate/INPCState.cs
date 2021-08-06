using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCState
{
    INPCState ChangeState(NPCBomb_StateManager npc);
}
