using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    private static int playerCount = 4;

    public static int PlayerCount
    {
        get
        {
            return playerCount;
        }
        set
        {
            if(value < 2)
                playerCount = 2;
            else if(value > 8)
                playerCount = 8;
            else
                playerCount = value;
        }
    }

    private static int startingLife = 40;

    public static int StartingLife
    {
        get
        {
            return startingLife;
        }
        set
        {
            if(value < 1)
                startingLife = 1;
            else
                startingLife = value;
        }
    }
}
