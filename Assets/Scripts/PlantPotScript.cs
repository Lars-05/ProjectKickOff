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
        meshFilter.mesh = plantStages[1];
    }

    public override void SharedUpdate()
    {
        float elapsedTime = plantCardScript.totalTime - plantCardScript.timeRemaining;
        if (plantCardScript.totalTime > elapsedTime)
        {


            timeBetweenStages = plantCardScript.totalTime / plantStages.Length;
            int targetIndex = Mathf.FloorToInt(elapsedTime / timeBetweenStages);

            targetIndex = Mathf.Clamp(targetIndex, 0, plantStages.Length - 1);


            if (targetIndex != index)
            {
                index = targetIndex;
                meshFilter.mesh = plantStages[index];
            }
        }

    }
}
