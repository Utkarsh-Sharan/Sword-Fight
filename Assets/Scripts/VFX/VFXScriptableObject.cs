using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "VFXScriptableObject", menuName = "ScriptableObject/VFXScriptableObject")]
public class VFXScriptableObject : ScriptableObject
{
    public VFXOwner VFXOwner;
    public VisualEffect VisualEffect;
}
