using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{

    string inputTime;
    public string stringResult;
    public TMP_Text txResult;
    public string sDefaultResult;

    // Start is called before the first frame update
    void Start()
    {
        changeToDefaultResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputTime12format(string s)
    {
        inputTime = s;

    }
    public void changeToDefaultResult()
    {

        txResult.text = sDefaultResult;
    }

    public void convertTime() {
        bool isError = false;
        string[] splitTime = inputTime.Split(':');
        string resultTime;
        if (splitTime.Length == 3)
        {
            if (splitTime[0] == "12" && splitTime[2].ToCharArray()[2] == 'A')
            {
                splitTime[0] = "00";
                splitTime[2] = splitTime[2].Split('A')[0];

            }
            else if (splitTime[2].ToCharArray()[2] == 'P' || splitTime[2].ToCharArray()[1] == 'P')
            {
                if (splitTime[0] != "12")
                {
                    int hourTemp = int.Parse(splitTime[0]) + 12;
                    splitTime[0] = hourTemp.ToString();
                }

                splitTime[2] = splitTime[2].Split('P')[0];
            }
            else if (splitTime[2].ToCharArray()[2] == 'A' || splitTime[2].ToCharArray()[1] == 'A')
            {
                splitTime[2] = splitTime[2].Split('A')[0];
            }
            else
            {
                isError = true;
            }
        }
        else
        {
            isError = true;
        }

        if (!isError)
        {
            resultTime = splitTime[0]+":" + splitTime[1] + ":" + splitTime[2];
        }
        else
        {
            resultTime = "wrong format Input";
        }
        
        txResult.text = resultTime;

    }
}
