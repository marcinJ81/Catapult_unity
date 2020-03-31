using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class Ball_Camera : MonoBehaviour
    {
        public GameObject ball;
        private Vector3 offset = new Vector3(-1,1, 0);
 
        void Start()
        {
            Vector3 startPosition = ball.transform.localPosition;
            transform.position = startPosition;
           
        }
        private void Update()
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
