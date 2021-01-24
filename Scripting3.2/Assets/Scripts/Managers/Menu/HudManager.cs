using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HudManager : MonoBehaviour
{
    PanelesManager panelRef;

    // Start is called before the first frame update
    void Start()
    {
        panelRef = GetComponent<PanelesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Misiones

    #region MisionNivel1

    void CompletarObjetivo(GameObject objetivo)
    {
        objetivo.GetComponent<Text>().color = Color.grey;
        objetivo.transform.SetAsLastSibling();
    }
    void CompletarSubObjetivo(GameObject subOjetivo)
    {
        subOjetivo.GetComponent<Text>().color = Color.grey;
        subOjetivo.transform.SetAsLastSibling();
    }



    #endregion



    #endregion
    public void AbrirNivel1()
    {
        panelRef.AbrirNivel1();
    }
    public void CerrarNivel1()
    {
        panelRef.CerrarNivel1();
    }
    public void SeleccionarClaseIzq()
    {
        panelRef.SeleccionarClaseIzq();
    }
    public void SeleccionarClaseCentro()
    {
        panelRef.SeleccionarClaseCentro();
    }
    public void SeleccionarClaseDer()
    {
        panelRef.SeleccionarClaseDer();
    }


}
