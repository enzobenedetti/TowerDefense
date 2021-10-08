using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Internal;

public class Money
{
    private static int _amount = 20;
    public static int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            if (_amount >= 0) return;
            _amount = 0;
        }
    }
}
