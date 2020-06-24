using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public enum PathStates {BFS,DFS,Astar};
    public PathStates pathSelected = PathStates.Astar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleBFS(bool isToggled)
    {
        if (isToggled)
        {
            Debug.Log("1");
            pathSelected = PathStates.BFS;
        }
    }

    public void ToggleDFS(bool isToggled)
    {
        if (isToggled)
        {
            Debug.Log("2");
            pathSelected = PathStates.DFS;
        }
    }

    public void ToggleAStar(bool isToggled)
    {
        if (isToggled)
        {
            Debug.Log("3");
            pathSelected = PathStates.Astar;
        }
    }

   
}
