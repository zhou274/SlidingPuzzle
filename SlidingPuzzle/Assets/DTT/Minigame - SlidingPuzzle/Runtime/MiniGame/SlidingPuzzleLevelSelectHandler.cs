using DTT.MinigameBase.LevelSelect;
using UnityEngine;

namespace DTT.MiniGame.SlidingPuzzle
{
    /// <summary>
    /// Class that implements a version of the Minigame Base level select.
    /// </summary>
    public class SlidingPuzzleLevelSelectHandler : LevelSelectHandler<LevelData, SlidingPuzzleResult, SlidingPuzzleManager>
    {
        /// <summary>
        /// A reference to the configs that will be used to set up levels.
        /// </summary>
        [SerializeField]
        private LevelData[] _configs;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="result"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        protected override float CalculateScore(SlidingPuzzleResult result) => result.score;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="levelNumber"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        protected override LevelData GetConfig(int levelNumber) => _configs[levelNumber % _configs.Length];
    }
}