using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PlantPotScript : IUpdaterBase, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private GameObject plantUI;
    [SerializeField] private Mesh[] plantStages;
    [SerializeField] private PlantCard plantCardScript;
    private int index = 0;
    private float timeBetweenStages;
    public void OnPointerDown(PointerEventData eventData)
    {
        plantCardScript.MakeVisible();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
 
    }
    public void OnPointerUp(PointerEventData eventData)
    {
     
    }
    
    public void ResetID()
    {
        index = 0;
        if (meshFilter != null && plantStages.Length > 0)
        {
            meshFilter.mesh = plantStages[0];
        }
    }

    public override void SharedUpdate()
    {
        timeBetweenStages = plantCardScript.totalTime / plantStages.Length;
        float elapsedTime = plantCardScript.totalTime - plantCardScript.timeRemaining;
        int targetIndex = Mathf.FloorToInt(elapsedTime / timeBetweenStages);
        Debug.Log(elapsedTime);
        
        targetIndex = Mathf.Clamp(targetIndex, 0, plantStages.Length - 1);

        
        if (targetIndex != index)
        {
            index = targetIndex;
            meshFilter.mesh = plantStages[index];
            Debug.Log($"Plant progressed to stage {index}");
        }

    }
}
