using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Maze
{
    public class SeedManager : MonoBehaviour
    {
        [SerializeField] private InputField seedInput;

        public static int seed;
        
        private void Start()
        {
            MainMenuState.OnExitMainMenuEvent += SeedRandom;
        }

        /**
         * Prepares random maze generation with given seed
         * or a random seed, if no seed has been chosen
         */
        private void SeedRandom()
        {
            if (Int32.TryParse(seedInput.text, out seed))
            {
                Random.InitState(seed);
            }
            else
            {
                Random.InitState(Random.Range(0, Int32.MaxValue));
            }
        }
    }
}