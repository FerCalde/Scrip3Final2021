using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    [SerializeField] Material[] materialesDisolve;
    public Renderer rend;
    public GameObject PowerUpTime;
    public float timer;
    public float SumaVidaPlayer;
    float delayMats;

    int i = 0;

    public float corpseTime;
    protected virtual void Start()
    {
        if (SumaVidaPlayer > 0)
        {
            GameObject newPowerUp = Instantiate(PowerUpTime, transform.position + new Vector3(0, 2, 0), transform.rotation);
            newPowerUp.GetComponent<TimePowerUp>().sumarVida = SumaVidaPlayer;
        }
        

        delayMats = corpseTime;
    }
    protected virtual void Update()
    {
        if (RewindManagment.isRewinding == true)
        {
            timer = 0f;
        }
        if (timer >= corpseTime)
        {

            /*int i = 0;
            while (i< (materialesDisolve.Length))
            {
                Debug.Log("funciona?" + i);
                rend.material = materialesDisolve[i];
                i++;
            }*/

            if (timer >= delayMats)
            {
                if (i < (materialesDisolve.Length))
                {

                    rend.material = materialesDisolve[i];
                    //Debug.Log(materialesDisolve[i]);
                    i++;

                }
                delayMats = timer + 0.2f;
            }

        }
        if (timer < corpseTime)
        {
            rend.material = materialesDisolve[0];
            i = 0;
            delayMats = corpseTime;
        }
        timer += 1 * Time.deltaTime;
        if (rend != null)
        {
            
        }
    }
}
