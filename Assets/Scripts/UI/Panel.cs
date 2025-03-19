using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private PanelType _panelType;

    public PanelType GetPanelType() => _panelType;
}
