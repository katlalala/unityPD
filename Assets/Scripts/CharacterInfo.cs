using UnityEngine;
using TMPro;
using System;

public class CharacterIdentity : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField yearInput;
    public TMP_Text resultText;
    

    public void CalculateAgeAndDisplay()
    {
        string charName = nameInput.text;
        
        // Try to convert the input string to a number
        if (int.TryParse(yearInput.text, out int birthYear))
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            // Requirement: "Supervaronis [Vārds] ir [Vecums] gadus vecs!"
            resultText.text = $"{charName} ir {age} gadus vecs!";
        }
        else
        {
            resultText.text = "Lūdzu, ievadiet derīgu gadu!";
        }
    }
}