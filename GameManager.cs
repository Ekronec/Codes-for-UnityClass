using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int totalCollectibles = 3;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private GameObject door;

    private int collected = 0;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectItem()
    {
        collected += 1;
        UpdateCounter();

        if (collected >= totalCollectibles)
        {
            door.SetActive(false);
        }
    }

    void UpdateCounter()
    {
        counterText.text =
            "Coins: " + collected + "/" + totalCollectibles;
    }
}
