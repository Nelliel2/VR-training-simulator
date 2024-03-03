using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private uint _usageLevel;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
            Instance = this;
        }

        OnLoadLevel();
    }

    private void OnLoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == _usageLevel)
            Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
