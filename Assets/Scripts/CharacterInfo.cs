using UnityEngine;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField yearInput;
    public TextMeshProUGUI resultText;

    public void GenerateResult()
    {
        string pName = nameInput.text;
        string pYear = yearInput.text;

        if (int.TryParse(pYear, out int birthYear))
        {
            // limits lidz 1900
            if (birthYear >= 1900 && birthYear <= 2026)
            {
                int age = 2026 - birthYear;
                resultText.text = $"{pName} is {age} years old!";

                nameInput.placeholder.GetComponent<TextMeshProUGUI>().text = pName;
                yearInput.placeholder.GetComponent<TextMeshProUGUI>().text = pYear;
                nameInput.text = "";
                yearInput.text = "";
            }
            else
            {
                resultText.text = "Please add a valid year.";
            }
        }
    }
}