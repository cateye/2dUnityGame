using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3l3 : MonoBehaviour
{
    public int myInteger = 5;
    public float myFloat = 3.5f;
    public bool myBoolean = true;
    public string myString = "Hello World";
    public int[] myArrayOfInts;

    private int _myPrivateInteger = 10;
    float _myPrivateFloat = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lets sum 10 to my integer. Right noe its value is:" + myInteger);
        myInteger += 10;
        Debug.Log("After the sum the value is: " + myInteger);

        if (IsEven(myInteger)){
            Debug.Log("Is Even");
        } else
        {
            Debug.Log("Is Odd");
        }

        for(int i = 0; i < myArrayOfInts.Length; i++)
        {
            Debug.Log(myArrayOfInts[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsEven(int num)
    {
        if (num % 2 == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
