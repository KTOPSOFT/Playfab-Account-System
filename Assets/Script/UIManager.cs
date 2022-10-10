using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject[] footers;
    // Start is called before the first frame update
    public void ShowPanel(int index)
    {
        for(int i = 0 ; i < panels.Length ; i ++)
        {
            if(i == index)
            {
                footers[i].SetActive(true);
                panels[i].SetActive(true);
            }
            else
            {
                footers[i].SetActive(false);
                panels[i].SetActive(false);
            }
        }
    }
}
