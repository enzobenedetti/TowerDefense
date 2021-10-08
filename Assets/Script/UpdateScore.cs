using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text killText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money : " + Money.Amount;
    }
}
