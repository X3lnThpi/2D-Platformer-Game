using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance;  } }

        public string Level1;
        public string[] Levels;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus =  (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
        }

        private void Start()
        {
            if (GetLevelStatus("Levels[0]") == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        public void MarkCurrentLevelComplete()
        {
            Scene CurrentScene = SceneManager.GetActiveScene();

            // Set level status to complete
            SetLevelStatus(CurrentScene.name, LevelStatus.Completed);

            // unlock the next level

            //int nextSceneIndex = (CurrentScene.buildIndex) + 1;
            //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
            //Debug.Log("Next scene is valid" + nextScene.IsValid()); 
            //LevelManager.Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

            //Working unlock next level code
            int CurrentSceneIndex = Array.FindIndex(Levels, Levels => Levels == CurrentScene.name);
            int nextSceneIndex = CurrentSceneIndex + 1;
            if (nextSceneIndex < (Levels.Length))
                {
                SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            }
        }

    }
}