using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PingPong
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] Text score = null;
        [SerializeField] Text best = null;
        [SerializeField] Text instruction = null;

        public void SetScore(uint value)
        {
            score.text = "Score: " + value;
        }

        public void SetBestResult(uint value)
        {
            best.text = "Best: " + value;
        }

        public void GameStarted()
        {
            instruction.gameObject.SetActive(false);
        }
    }
}