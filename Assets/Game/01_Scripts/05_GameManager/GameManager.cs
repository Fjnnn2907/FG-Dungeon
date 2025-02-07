using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SingleTon
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public PlayerManager playerManager;
    public CointManager cointManager;
    public Inventory inventoryManager;
    public SoundManager soundManager;
    protected void Reset()
    {
        playerManager = GetComponentInChildren<PlayerManager>();
        cointManager = GetComponentInChildren<CointManager>();
        inventoryManager = GetComponentInChildren<Inventory>();
        soundManager = GetComponentInChildren<SoundManager>();
    }
}
