using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class SRandomObjectPosition
    {
        //courdinates for wall, wall is on the ground group
        private static float z_min = -0.3f;
        private static float z_max = 0.3f;
        private static float x_min = -0.4f;
        private static float x_max = 0.4f;
        private static float y_min = 5f;
        private static IRandomizeObjectPosition randomPosition;
        static SRandomObjectPosition()
        {
            SRandomObjectPosition.randomPosition = new RandomizeObjectPosition();
            SRandomObjectPosition.randomPosition.SetCoordinates("X", x_min, x_max);
            SRandomObjectPosition.randomPosition.SetCoordinates("Y", y_min, y_min);
            SRandomObjectPosition.randomPosition.SetCoordinates("Z", z_min, z_max);
        }
        public static Vector3 GetRandomPosition()
        {
            return SRandomObjectPosition.randomPosition.RandomObjectPosition();
        }

    }
}
