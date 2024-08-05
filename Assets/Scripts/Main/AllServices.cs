using UnityEngine;

public class AllServices : MonoBehaviour
{
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    private static AllServices _instance;

    public static AllServices Container => _instance;

    [SerializeField] private InputService _inputService;

    public IInputService InputService => _inputService;
}
