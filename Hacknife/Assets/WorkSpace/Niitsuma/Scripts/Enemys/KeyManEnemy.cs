using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManEnemy : BasePatrol
{
    void Update()
    {
        if (_searchTrigger.IsSearch) { PlayerLook(); }
    }
}
