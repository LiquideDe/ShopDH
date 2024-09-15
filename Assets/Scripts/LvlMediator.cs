using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMediator
{
    private LvlFactory _lvlFactory;
    private PresenterFactory _presenterFactory;
    

    public LvlMediator(LvlFactory lvlFactory, PresenterFactory presenterFactory)
    {
        _lvlFactory = lvlFactory;
        _presenterFactory = presenterFactory;

        Subscribe();
    }

    public void MainMenu()
    {

    }
    private void Subscribe()
    {

    }

   

    
}
