using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text killText;
    [SerializeField] private Text waveText;

    private static int score;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money : " + Money.Amount;
        killText.text = "Score : " + score;
        waveText.text = "Wave : " + WaveSystem.wave;
    }

    public static void AddScore()
    {
        score++;
    }
}
