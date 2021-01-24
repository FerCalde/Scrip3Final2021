using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] float maxScale = 5f;
    [SerializeField] float minScale = 2.3f;
    [SerializeField] float speedChangeScale = 2.2f;
    bool isGrowing = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit infoImpacto;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out infoImpacto))
        {
            if (infoImpacto.transform.tag == "NivelDesbloqueado")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    LevelManager.Instance.SeleccionNivel(infoImpacto.transform.gameObject);
                }
                if (isGrowing)
                {
                    if (infoImpacto.transform.localScale.x <= maxScale)
                    {
                        infoImpacto.transform.localScale += Vector3.one * speedChangeScale * Time.deltaTime;

                    }
                    else
                    {
                        isGrowing = false;
                    }
                }
                if (!isGrowing)
                {
                    if (infoImpacto.transform.localScale.x >= minScale)
                    {
                        infoImpacto.transform.localScale -= Vector3.one * speedChangeScale * Time.deltaTime;
                    }
                    else
                    {
                        isGrowing = true;
                    }
                }
            }

        }

    }

}
