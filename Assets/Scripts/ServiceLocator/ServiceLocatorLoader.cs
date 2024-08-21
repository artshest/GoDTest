using UnityEngine;

public class ServiceLocatorLoader : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    [SerializeField] private SceneController _sceneController;

    private void Awake()
    {
        ServiceLocator.Initialize();
        _serviceLocator = ServiceLocator.Instance;
        RegisterServices();
    }

    private void RegisterServices()
    {
        _serviceLocator.Register(_sceneController);
    }
}
