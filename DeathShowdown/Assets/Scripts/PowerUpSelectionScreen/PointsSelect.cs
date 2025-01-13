using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSelect : MonoBehaviour
{
    public void SetPoints(int points)
    {
        if (points == 0)
        {
            PlayerConfigManager.ffaMaxPoints = 3;
        }
        if (points == 1)
        {
            PlayerConfigManager.ffaMaxPoints = 5;
        }
        if (points == 2)
        {
            PlayerConfigManager.ffaMaxPoints = 10;
        }
        if (points == 3)
        {
            PlayerConfigManager.ffaMaxPoints = 15;
        }

        
    }
}
