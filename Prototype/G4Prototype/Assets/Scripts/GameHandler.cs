using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _Instance;

    public static GameHandler Instance { get { return _Instance; } }

    public enum gameStates
    {
        navigating,
        selection
    }

    public gameStates gameState;

    public int buttonSelected;
    public bool buttonClickedOn = false;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _Instance = this;
        }

        gameState = gameStates.navigating;
    }

    public void buttonClicked(int buttonIdentfier)
    {
        buttonSelected = buttonIdentfier;
        buttonClickedOn = true;
    }
}
