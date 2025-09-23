using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

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
    }
        
    public void Awake()
    {
        timeBetweenStages = plantCardScript.totalTime / plantStages.Length;
    }

    public override void SharedUpdate()
    {
   
        if (plantCardScript.timeRemaining < plantCardScript.totalTime - index * timeBetweenStages)
        {
            //index += 1;
            //meshFilter.mesh = plantStages[index - 1];
        }

    }
}
