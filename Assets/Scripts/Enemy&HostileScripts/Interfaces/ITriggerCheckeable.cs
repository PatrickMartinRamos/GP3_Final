using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckeable
{
    bool isInPlace { get; set; }
    void SetInPlaceStatus(bool isInPlace);
}
