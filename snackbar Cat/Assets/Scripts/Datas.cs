using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{

    [SerializeField] private GameObject[] tables;
    [SerializeField] private GameObject[] seller;

    public bool IsThereEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)      return true;
                                                            return false;
    }

    public Vector3 LocationOfEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)
            {
                tables[i].GetComponent<Tables>().SetFull();
                return tables[i].transform.position;
            }
        return new Vector3(0, 0, 0);
    }
}
