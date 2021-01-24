using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelesManager : MonoBehaviour
{
    [Header("Nivel 1")]
    public GameObject panelNivel1;
    public Image claseIzqImg;
    public Image claseCentroImg;
    public Image claseDerImg;

    // Start is called before the first frame update
    void Start()
    {
        panelNivel1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Nivel 1
    public void AbrirNivel1()
    {
        panelNivel1.SetActive(true);
    }
    public void CerrarNivel1()
    {
        panelNivel1.SetActive(false);
    }
    public void SeleccionarClaseIzq()
    {
        claseIzqImg.color = Color.red;
        claseCentroImg.color = Color.white;
        claseDerImg.color = Color.white;

    }
    public void SeleccionarClaseCentro()
    {
        claseIzqImg.color = Color.white;
        claseCentroImg.color = Color.red;
        claseDerImg.color = Color.white; 
    }
    public void SeleccionarClaseDer()
    {
        claseIzqImg.color = Color.white;
        claseCentroImg.color = Color.white;
        claseDerImg.color = Color.red;
    }

    #endregion
}
