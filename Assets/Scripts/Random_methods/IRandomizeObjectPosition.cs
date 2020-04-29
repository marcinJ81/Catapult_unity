using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{ 
    public interface IRandomizeObjectPosition
    {
        Vector3 RandomObjectPosition();
        void SetCoordinates(string cordinatesName,float minValue, float maxValue);
       
    }
    
    public class RandomizeObjectPosition : IRandomizeObjectPosition
    {
        private List<CoordinatesForRandomoize> coordinates { get; set; }
        public RandomizeObjectPosition()
        {
            this.coordinates = new List<CoordinatesForRandomoize>();
        }
        public void SetCoordinates(string cordinatesName, float minValue, float maxValue)
        {
            this.coordinates.Add
               (
                   new CoordinatesForRandomoize
                   {
                       Coordinates_Name = cordinatesName,
                       Coordinates_ValueMin = minValue,
                       Coordinates_ValueMax = maxValue
                   }
               );
        }
        public Vector3 RandomObjectPosition()
        {
            float randomX = 0;
            float randomZ = 0;
            float randomY = 0;

            if (this.coordinates.Any())
            {
                randomX = UnityEngine.Random.Range(
                        this.coordinates.Where(i => i.Coordinates_Name == "X").FirstOrDefault().Coordinates_ValueMin
                      , this.coordinates.Where(i => i.Coordinates_Name == "X").FirstOrDefault().Coordinates_ValueMax);
                randomY = UnityEngine.Random.Range(
                        this.coordinates.Where(i => i.Coordinates_Name == "Y").FirstOrDefault().Coordinates_ValueMin
                      , this.coordinates.Where(i => i.Coordinates_Name == "Y").FirstOrDefault().Coordinates_ValueMax);
                randomZ = UnityEngine.Random.Range(
                        this.coordinates.Where(i => i.Coordinates_Name == "Z").FirstOrDefault().Coordinates_ValueMin
                      , this.coordinates.Where(i => i.Coordinates_Name == "Z").FirstOrDefault().Coordinates_ValueMax);
                Vector3 objectPosition = new Vector3(randomX, randomY, randomZ);
                return objectPosition;
            }
            else
            {
                Vector3 objectPosition = new Vector3(randomX, randomY, randomZ);
                return objectPosition;
            }

        }

        
    }
}
