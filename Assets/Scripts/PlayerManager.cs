using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private uint _usageLevel;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        OnLoadLevel();
    }

    private void OnLoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == _usageLevel)
            Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
