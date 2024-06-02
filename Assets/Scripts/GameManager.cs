using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _gameManager : MonoBehaviour
{
   public bool isCoopMode = false;
    [SerializeField]
    public bool gameover = true;
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public GameObject _coopPlayers;

    private UIManager _uiManager;

    public static _gameManager Instance;
    private SpawnManager _spawnManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (isCoopMode == true)
        {
            _spawnManager.StartSpawning();
        }
    }

    private void Update()
    {
        if (gameover == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isCoopMode == false)
                {
                    Instantiate(Player, Vector3.zero, Quaternion.identity);
                }
                gameover = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawning();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Game Restarted...");
                SceneManager.LoadScene("Single_Player");
            }
        }
    }

     internal void HideTitleScreen()
    {
      
    }
}