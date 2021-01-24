using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewindHUD : MonoBehaviour
{
    GameObject goPlayer;

    [SerializeField] Image imgRewind;
    [SerializeField] RewindManagment cmpRewindMang;
    float refCooldownRewind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //refCooldownRewind -= Time.deltaTime;
        
        float porcentaje = Time.time / refCooldownRewind;
        if (refCooldownRewind <= 0)
        {
            refCooldownRewind = 0;
        }
        //print(porcentaje+" PORCENTAJE");
        imgRewind.fillAmount = porcentaje;
    }


    public void GetCooldownRewind(float cooldownRewind)
    {
        refCooldownRewind = cooldownRewind;
    }

}
