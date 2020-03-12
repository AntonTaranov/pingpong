using System;
using UnityEngine;

namespace PingPong
{
    public class ScoreStorage
    {
        const string BEST_KEY = "best_score";
        uint bestScore = 0;

        public ScoreStorage()
        {
            if (PlayerPrefs.HasKey(BEST_KEY))
            {
                bestScore = (uint)PlayerPrefs.GetFloat(BEST_KEY);
            }
        }

        public uint Best
        {
            get => bestScore;
            set
            {
                PlayerPrefs.SetFloat(BEST_KEY, value);
                PlayerPrefs.Save();
                bestScore = value;
            }
        }
    }
}