using UnityEngine;

public abstract class IUpdaterBase : MonoBehaviour, Updater.IUpdater
{
    
    void OnEnable()
    {
        var updater = FindFirstObjectByType<Updater>();
        if (updater != null)
            updater.SubscribeToUpdater(this);
    }

    void OnDisable()
    {
        var updater = FindFirstObjectByType<Updater>();
        if (updater != null)
            updater.UnSubscribeToUpdater(this);
    }

    // This is required by IUpdater
    public abstract void SharedUpdate();
   
}
