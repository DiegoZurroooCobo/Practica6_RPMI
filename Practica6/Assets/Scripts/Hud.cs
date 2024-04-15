using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    private TMP_Text text;
    public GameManager.GameManagerVariables variable;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
       switch(variable)
        {
            case GameManager.GameManagerVariables.TIME:
                text.text = "Time: " + GameManager.instance.GetTime().ToString("#.##");
                break;
            case GameManager.GameManagerVariables.POINTS:
                text.text = "Points: " + GameManager.instance.GetPoints();
                break;
        }
    }
}