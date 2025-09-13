using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    public IUpdater updater;
    public List<IUpdater> updateRecievers = new List<IUpdater>();
    public interface IUpdater
    { 
        void SharedUpdate();
    }

    public void SubscribeToUpdater(IUpdater updater)
    {
        updateRecievers.Add(updater);
    }
    public void UnSubscribeToUpdater(IUpdater updater)
    {
        updateRecievers.Remove(updater);
    }
    public void Update()
    {
        foreach (var updaterReceiver in updateRecievers)
        {
            updaterReceiver.SharedUpdate();
        }
    }
}


