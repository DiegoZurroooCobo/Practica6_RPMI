using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LIFE : MonoBehaviour
{
  public GameObject[] vidas;
    public void DesactiveLifes(int index)
    {
        vidas[index].SetActive(false);
    }
    public void ActiveLifes(int index)
    {
        vidas[index].SetActive(true);
    }
}
