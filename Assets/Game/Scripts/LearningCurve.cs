using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public int num1;
    public int num2;
    public M_Opperation operation;
    public object cat;
    // Start is called before the first frame update
    void Start()
    {
        switch(operation)
        {
            case M_Opperation.addition:
                Debug.Log(num1 + num2);
                break;
            case M_Opperation.subtraction:
                Debug.Log(num1 - num2);
                break;
            case M_Opperation.multiplication:
                Debug.Log(num1 * num2);
                break;
            case M_Opperation.division:
                Debug.Log(num1 / num2);
                break;
        }
    }
}
[System.Serializable]
public enum M_Opperation
{
    addition,
    subtraction,
    multiplication,
    division
}
