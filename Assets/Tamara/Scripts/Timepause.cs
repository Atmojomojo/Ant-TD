using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePause : MonoBehaviour
{
    
        private bool isPaused = false;

        public void PauseTime()
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }

        public void ResumeTime()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    
}
