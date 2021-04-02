using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private bool battleActive;

    public GameObject battleScene;

    public Transform[] playerPositions;
    public Transform[] enemyPositions;

    public BattleCharacter[] playerPrefabs;
    public BattleCharacter[] enemyPrefabs;

    public List<BattleCharacter> activeBattlers = new List<BattleCharacter>();

    float timeSinceEnemyLastAttack = 0;
    float timeSincePlayerLastAttack = 0;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BattleStart(new string[] { "Slime" });
        }

        if (battleActive)
        {
            timeSinceEnemyLastAttack += Time.deltaTime;
            timeSincePlayerLastAttack += Time.deltaTime;
            EnemyAttack();
            PlayerAttack();
        }
    }

    public void BattleStart(string[] enemiesToSpawn)
    {
        if (!battleActive)
        {
            battleActive = true;
                        
            PlayerController.instance.canMove = false;

            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);

            battleScene.SetActive(true);

            for (int i = 0; i < playerPositions.Length; i++)
            {
                if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
                {
                    for (int j = 0; j < playerPrefabs.Length; j++)
                    {
                        if (playerPrefabs[j].characterName == GameManager.instance.playerStats[i].charName)
                        {
                            BattleCharacter newPlayer = Instantiate(playerPrefabs[j], playerPositions[i].position, playerPositions[i].rotation);
                            newPlayer.transform.parent = playerPositions[i];
                            activeBattlers.Add(newPlayer);

                            CharacterStats thePlayer = GameManager.instance.playerStats[i];
                            activeBattlers[i].currentHP = thePlayer.currentHP;
                            activeBattlers[i].maxHP = thePlayer.maxHP;
                        }
                    }                        
                }
            }

            for (int i = 0; i < enemiesToSpawn.Length; i++)
            {
                if (enemiesToSpawn[i] != "")
                {
                    for(int j = 0; j < enemyPrefabs.Length; j++)
                    {
                        if (enemyPrefabs[j].characterName == enemiesToSpawn[i])
                        {
                            BattleCharacter newEnemy = Instantiate(enemyPrefabs[j], enemyPositions[i].position, enemyPositions[i].rotation);
                            newEnemy.transform.parent = enemyPositions[i];
                            activeBattlers.Add(newEnemy);
                        }                        
                    }
                }
            }
        }
    }

    public void EnemyAttack()
    {
        List<int> players = new List<int>();
        for (int i = 0; i <activeBattlers.Count; i ++)
        {
            if (activeBattlers[i].isPlayer && activeBattlers[i].currentHP > 0)
            {
                players.Add(i);
            }
        }

        int selectedTarget = players[Random.Range(0, players.Count)];
        

        if (timeSinceEnemyLastAttack > 1f)
        {
            activeBattlers[selectedTarget].currentHP -= 1;
            Debug.Log(activeBattlers[selectedTarget].characterName + activeBattlers[selectedTarget].currentHP);
            timeSinceEnemyLastAttack = 0;
        }

        
    }

    public void PlayerAttack()
    {
        List<int> enemies = new List<int>();
        for (int i = 0; i < activeBattlers.Count; i++)
        {
            if (!activeBattlers[i].isPlayer && activeBattlers[i].currentHP > 0)
            {
                enemies.Add(i);
                
            }
        }

        int selectedTarget = enemies[Random.Range(0, enemies.Count)];
        




        if (timeSincePlayerLastAttack > 1f)
        {
            activeBattlers[selectedTarget].currentHP -= 10;
            Debug.Log(activeBattlers[selectedTarget].characterName + activeBattlers[selectedTarget].currentHP);
            timeSincePlayerLastAttack = 0;
        }
    }
}
