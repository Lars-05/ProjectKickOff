using TMPro;
using UnityEngine;

public class showstats : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void Start()
    {
        text1.text = Screen.width.ToString();
        text2.text = Screen.height.ToString();
    }
}
