using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.GameActualState = GameManager.GameState.InGame;
    }
}
