using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
    [SerializeField] private List<Panel> _panelList;

    private Dictionary<PanelType, Panel> _panelDictionary;
    private Panel _currentlyOpenPanel;

    private EventService _eventService;

    private void Start()
    {
        _panelDictionary = new Dictionary<PanelType, Panel>();
        foreach(Panel panel in _panelList)
            _panelDictionary[panel.GetPanelType()] = panel;
    }

    public void Dependency(EventService eventService)
    {
        _eventService = eventService;
        _eventService.OnPlayerDeathEvent.AddListener(OnPlayerDeath);
        _eventService.OnLevelWinEvent.AddListener(OnLevelWin);
    }

    private void OnPlayerDeath() => OpenNewPanel(PanelType.Game_Over);
    private void OnLevelWin() => OpenNewPanel(PanelType.Game_Win);      //currently only opening game win panel on winning level, will add new levels later.

    private void OpenNewPanel(PanelType panelType)
    {
        if(_currentlyOpenPanel != null)
            _currentlyOpenPanel.gameObject.SetActive(false);

        _currentlyOpenPanel = _panelDictionary[panelType];
        _currentlyOpenPanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _eventService.OnPlayerDeathEvent.RemoveListener(OnPlayerDeath);
        _eventService.OnLevelWinEvent.RemoveListener(OnLevelWin);
    }
}

public enum PanelType
{
    Game_Over,
    Game_Win
}