﻿using UnityEngine;
using StateStuff;

public class SecondState : State<AI>
{
    private static SecondState _instance;
    private static int trigger = 0;

    private SecondState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static SecondState Instance
    {
        get
        {
            if (_instance == null)
            {
                new SecondState();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering Second State");
        RushAttack.trigger = 1;
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Second State");
    }

    public override void UpdateState(AI _owner)
    {
    }
}
