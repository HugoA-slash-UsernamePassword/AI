using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoneHome
{
    public class GameManager : MonoBehaviour
    {

        // Use this for initialization
        public void NextLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        // Update is called once per frame
        public void RestartLevel()
        {
            FollowEnemy[] followEnemies = FindObjectsOfType<FollowEnemy>();
            PatrolEnemy[] patrolEnemies = FindObjectsOfType<PatrolEnemy>();
            //GoneHome.FairlyUselessScript[] patrolEnemies = FindObjectsOfType<PatrolEnemy>();
            foreach (var enemy in followEnemies)
            {
                enemy.Reset();
            }
            foreach (var enemy in patrolEnemies)
            {
                enemy.Reset();
            }
            // Grab the player in the scene
            Player player = FindObjectOfType<Player>();
            // Reset player
            player.Reset();
            // Grab the player in the scene
            Goal goal = FindObjectOfType<Goal>();
            // Reset player
            player.Reset();
        }
    }
}
