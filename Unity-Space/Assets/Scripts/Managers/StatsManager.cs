using System;
using LudumDare50.Models;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace LudumDare50.Unity.Managers
{
    public class StatsManager : MonoBehaviour
    {
        private const string PlayerPrefsIdKey = "PlayerId";
        private const string PlayerPrefsStatsKey = "PlayerStats";
        
        public static StatsManager Instance;

        public string Id { get; private set; }
        public Stats Stats { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadLocal();
        }

        private void LoadLocal()
        {
            Id = PlayerPrefs.HasKey(PlayerPrefsIdKey)
                ? PlayerPrefs.GetString(PlayerPrefsStatsKey)
                : Guid.NewGuid().ToString();
            
            if (PlayerPrefs.HasKey(PlayerPrefsStatsKey))
            {
                var json = PlayerPrefs.GetString(PlayerPrefsStatsKey);
                Debug.Log(json);
                try
                {
                    Stats = JsonConvert.DeserializeObject<Stats>(json);
                    return;
                }
                catch
                {
                    //This is intentional
                }
            }
            Stats = new Stats();
        }

        public void Save()
        {
            SaveLocal();
            try
            {
                //SaveRemote();
            }
            catch
            {
                // Do nothing
            }
        }
        
        private void SaveLocal()
        {
            Stats.Id = Id;
            Stats.Version++;
            Stats.UpdatedAt = DateTime.Now;
            
            var json = JsonConvert.SerializeObject(Stats);
            PlayerPrefs.SetString(PlayerPrefsStatsKey, json);
            PlayerPrefs.Save();
        }
        
        private void SaveRemote()
        {
            var json = JsonConvert.SerializeObject(Stats, Formatting.Indented);
            Debug.Log(json);
        
            var url = $"{Constants.ApiUrl}/games/out-of-air/client/{Id}/stats";
            Debug.Log(url);
        
            RestClient.Put(url, json)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not save the player.{Environment.NewLine}{error.Message}");
                });
        }
    }
}