using System;
using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Windows
{
    public class StatsWindow : MonoBehaviour
    {
        [SerializeField] private Text _bodyText;

        private void OnEnable()
        {
            var stats = StatsManager.Instance.Stats;
            _bodyText.text = $"<b>Time Played:</b> {TimeToString(stats.TimePlayed)}{Environment.NewLine}"
                             + $"<b>Rounds Played:</b> {stats.RoundsPlayed}{Environment.NewLine}"
                             + $"<b>Total Cans Collected:</b> {stats.CansCollected}{Environment.NewLine}"
                             + Environment.NewLine
                             + $"<b>Longest Round:</b> {TimeToString(stats.LongestRound)}{Environment.NewLine}"
                             + $"<b>Most Cans Collected:</b> {stats.MostCansCollected}";
        }

        private string TimeToString(int time)
        {
            var hours = time / 3600;
            var minutes = time / 60;
            var seconds = time % 60;

            if (hours > 0)
            {
                return $"{hours}h {minutes}m {seconds}s";
            }
            else if (minutes > 0)
            {
                return $"{minutes}m {seconds}s";
            }
            else
            {
                return $"{seconds}s";
            }
        }
    }
}