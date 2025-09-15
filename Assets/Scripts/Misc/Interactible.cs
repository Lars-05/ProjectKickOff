using UnityEngine;
using UnityEngine.EventSystems;

public class Interactible : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject window;
    [SerializeField] private AudioSource audio; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if (window.activeSelf == false)
        {
            window.SetActive(true);
            audio.Play();
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
