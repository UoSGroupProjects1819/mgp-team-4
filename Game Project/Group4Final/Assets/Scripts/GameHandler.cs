using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _Instance;

    public static GameHandler Instance { get { return _Instance; } }

    public GameObject playerGameObject;

    public enum gameStates
    {
        navigating,
        selection
    }

    public gameStates gameState;

    public enum levels
    {
        LEVEL_1,
        LEVEL_2,
        LEVEL_3,
        MAX_LEVEL,        
        LEVEL_4,
        LEVEL_5        
    }

    public levels currentLevel;

    public List<GameObject> levelSpawners;

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
        currentLevel = levels.LEVEL_1;
    }

    public void buttonClicked(int buttonIdentfier)
    {
        buttonSelected = buttonIdentfier;
        buttonClickedOn = true;
    }

    public void nextLevel()
    {
        if(currentLevel + 1 != levels.MAX_LEVEL)
        {
            currentLevel = currentLevel + 1;
        }

        playerGameObject.transform.position = levelSpawners[(int)currentLevel].transform.position;
        playerGameObject.transform.rotation = levelSpawners[(int)currentLevel].transform.rotation;
    }
}
