using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public TMP_Text colorText;
    public Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
    public string[] colorNames = { "Red", "Blue", "Green", "Yellow" };
    private int currentIndex = 0;

    private Renderer targetObject;

    void Start()
    {
        targetObject = GetComponent<Renderer>();
        
        ApplyCurrentColor();
    }


    public void OnColorButtonClicked()
    {
        // Move to the next index, looping back to 0 if we reach the end
        currentIndex++;
        if (currentIndex >= colors.Length)
        {
            currentIndex = 0;
        }

        ApplyCurrentColor();
    }

    private void ApplyCurrentColor()
    {
        // 1. Change the 3D object's material color
        if (targetObject != null)
        {
            // targetObject.material.color = colors[currentIndex]; 
            targetObject.material.SetColor("_BaseColor", colors[currentIndex]);
        }

        // 2. Update the UI Text
        if (colorText != null)
        {
            colorText.text = colorNames[currentIndex];
        }
    }
}
