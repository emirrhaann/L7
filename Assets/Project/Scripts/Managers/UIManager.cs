using System;
using System.Collections.Generic;
using Project.Scripts.Utils;
using TMPro;
using UnityEngine;
public class UIManager : MonoSingleton<UIManager>
{
    OnTriggers OnTriggers;
    [SerializeField] private List<Panel> panels = new List<Panel>();
    [SerializeField] private TextMeshProUGUI winLevelText = null;
    [SerializeField] private TextMeshProUGUI loseLevelText = null;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    private void Start()
    {
        OnTriggers = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
         currentLevelText.text = "LEVEL " + (PlayerPrefs.GetInt("levelkey") + 1);
    }
    public void ShowPanel(PanelType panelType, bool hideOthers = true)
    {
        panels.ForEach(p =>
        {
            if (p.panelType == panelType || panelType == PanelType.All)
                p.Show();
            else if (hideOthers)
                p.Hide();
        });
    }
  
    public void HidePanel(PanelType panelType)
    {
        panels.ForEach(p =>
        {
            if (p.panelType == panelType || panelType == PanelType.All)
                p.Hide();
        });
    }
    public void UpdateLevelText()
    {
        currentLevelText.text = $"LEVEL {LevelManager.PrefsLevelKey}";
    }
    public void UpdateLevelTexts()
    {
        int level = PlayerPrefs.GetInt(LevelManager.PrefsLevelKey) + 1;
        if (winLevelText)
        {
            winLevelText.text = $"Level {level} Completed";
        }
        if (loseLevelText)
        {
            loseLevelText.text = $"Level {level} Failed";
        }
    }

    public void UpgradeDamage()
    {
        if (OnTriggers.coincount >= 7)
        {
            OnTriggers.coincount -= 7;
            OnTriggers.damage = 15;
        }
    }
}
[Serializable]
public class Panel
{
    public GameObject panelObject;
    public PanelType panelType = PanelType.None;
    public void Show() => panelObject.SetActive(true);
    public void Hide() => panelObject.SetActive(false);
}
public enum PanelType
{
    None,
    Tutorial,
    All,
    TapToPlay,
    GamePlay,
    Win,
    Lose,
}