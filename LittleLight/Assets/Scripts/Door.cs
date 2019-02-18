using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggeeScript
{
    public override void Triggered()
    {
        Destroy(gameObject);
    }
}
