using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
    [SerializeField] private List<Panel> _panelList;

    private Dictionary<PanelType, Panel> _panelDictionary;
    private Panel _currentlyOpenPanel;

    private void Start()
    {
        _panelDictionary = new Dictionary<PanelType, Panel>();
        foreach(Panel panel in _panelList)
            _panelDictionary[panel.GetPanelType()] = panel;
    }

    public void Dependency(EventService eventService)
    {
        eventService.OnPlayerDeathEvent.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath() => OpenNewPanel(PanelType.Game_Over);

    public void OpenNewPanel(PanelType panelType)
    {
        if(_currentlyOpenPanel != null)
            _currentlyOpenPanel.gameObject.SetActive(false);

        _currentlyOpenPanel = _panelDictionary[panelType];
        _currentlyOpenPanel.gameObject.SetActive(true);
    }
}

public enum PanelType
{
    Game_Over,
    Game_Win
}