using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public enum PathStates {BFS,DFS,Astar};
    public PathStates pathSelected = PathStates.Astar;

    [SerializeField] private GameObject pathLength;
    [SerializeField] private GameObject pathCalcTime;

    private TextMeshProUGUI pathLengthText;
    private TextMeshProUGUI pathCalcText;

    // Start is called before the first frame update
    void Start()
    {
        pathLengthText = pathLength.GetComponent<TextMeshProUGUI>();
        pathCalcText = pathCalcTime.GetComponent<TextMeshProUGUI>();
        
    }

    public void ToggleBFS(bool isToggled)
    {
        if (isToggled)
        {
            pathSelected = PathStates.BFS;
        }
    }

    public void ToggleDFS(bool isToggled)
    {
        if (isToggled)
        {
            pathSelected = PathStates.DFS;
        }
    }

    public void ToggleAStar(bool isToggled)
    {
        if (isToggled)
        {
            pathSelected = PathStates.Astar;
        }
    }

    public void UpdatePathLenthText(string pathLength)
    {
        pathLengthText.SetText(pathLength);
    }

    public void UpdatePathCalcText(string pathCalcTime)
    {
        pathCalcText.SetText(pathCalcTime);
    }

}
