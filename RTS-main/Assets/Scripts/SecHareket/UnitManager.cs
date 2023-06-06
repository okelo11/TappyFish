using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
    RaycastHit hit;
    List<UnitController> secim = new List<UnitController>();
    bool isDragging = false;
    Vector3 mousePositon;
    


    void Update()
    {
        //farenin kapal� olup olmad���n� alg�la
        if (Input.GetMouseButtonDown(0))
        {
            mousePositon = Input.mousePosition;
            //kameradan uzay�m�za bir ���n olu�turun
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //o ���n� vur ve isabet verilerini al
            if (Physics.Raycast(camRay, out hit))
            {
                //bu verilerle bir �eyler yap�n
                // Debug.Log(hit.transform);

                if (hit.transform.CompareTag("Tank") || hit.transform.CompareTag("Bisiklet"))
                {
                    Debug.Log("secimlendi");
                    SecimBirimi(hit.transform.GetComponent<UnitController>(),Input.GetKey(KeyCode.LeftShift));

                }
                else if (hit.transform.CompareTag("Zemin"))
                {
                    
                    SecimBiriminiKaldir();
                    isDragging = true;
                }
            }

        }

        if (Input.GetMouseButtonDown(1) && secim.Count > 0)
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Shoot that ray and get the hit data
            if (Physics.Raycast(camRay, out hit))
            {
                //Do something with that data 
                //Debug.Log(hit.transform.tag);
                if (hit.transform.CompareTag("Zemin"))
                {
                    Debug.Log("zemin");
                    foreach (var selectableObj in secim)
                    {
                        selectableObj.HareketBirimi(hit.point);
                    }
                }
                else if (hit.transform.CompareTag("Bina"))
                {
                    foreach (var selectableObj in secim)
                    {
                        selectableObj.YeniHedefBelirle(hit.transform);
                    }
                }
            }
        }
    }

    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenManager.GetScreenRect(mousePositon, Input.mousePosition);
            
        }

    }




    private void SecimBirimi(UnitController unit, bool cokluSecim = false)
    {
        if (!cokluSecim)
        {
            SecimBiriminiKaldir();
        }
        secim.Add(unit);
        //unit.Find("I��k").gameObject.SetActive(true);
        unit.SecimiAyarla(true);
    }

    private void SecimBiriminiKaldir()
    {
        for (int i = 0; i < secim.Count; i++)
        {
            //secimBirimi[i].Find("I��k").gameObject.SetActive(false);
            secim[i].SecimiAyarla(false);     
        }
        secim.Clear();
        
    }

    public void Degistir()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.tag = "Tank";

        }
    }

}
