using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HabilidadCopiaEspectro : HabilidadBase
{


    [SerializeField] float spectreDistanceMin = 0.2f;

    [SerializeField] float speedSpectreBackOrigin = 2f;
    float porcentajeTempoOut;
    [SerializeField] float porcentajeTempoFeedback = 30f;
    [SerializeField] GameObject modelPlayer, vfxParticleBack;

    [SerializeField] GameObject prefEspectoVFX;
    [SerializeField] GameObject prefStartSpectreVFX;
    [SerializeField] GameObject prefTrailSpectreVFX;


    Transform startPositionTransform;

    GameObject newEspectro;

    bool spectreActive = false;

    bool spectrePosition = false;


    [SerializeField] Image panelHabilidadFilter;
    [SerializeField] bool filterHabilidad = true;

    // Start is called before the first frame update
    void Start()
    {
        modelPlayer.GetComponent<SkinnedMeshRenderer>().enabled = true;
        vfxParticleBack.SetActive(false);
        prefTrailSpectreVFX.SetActive(false);
        prefStartSpectreVFX.SetActive(false);


        porcentajeTempoOut = (tiempoDuracionActivadoMaximo * porcentajeTempoFeedback) / 100;
        //startPositionTransform = this.transform;

        panelHabilidadFilter.enabled = false;
    }

    protected override void Update()
    {

        tiempoCooldownActual -= Time.deltaTime;
        if (tiempoCooldownActual <= 0)
        {
            tiempoCooldownActual = 0;
        }

        tiempoDuracionActivaActual += Time.deltaTime;
        if (tiempoDuracionActivaActual >= tiempoDuracionActivadoMaximo)
        {
            //spectrePosition = false;
            if (spectreActive)
            {
                DesactivarEfecto();

                /*if (tiempoDuracionActivaActual <= (tiempoDuracionActivadoMaximo - porcentajeTempoOut))
                {
                    //StartCoroutine(ParpadeoModel());
                    //modelPlayer.GetComponent<SkinnedMeshRenderer>().enabled = false;
                    //
                }*/

            }
            tiempoDuracionActivaActual = tiempoDuracionActivadoMaximo;
        }

    }


    protected override void AplicarEfecto()
    {
        GetComponent<VidaJugador>().ActivarInmunidadTemporal(tiempoDuracionActivadoMaximo);
        spectreActive = true;
        isActiveHability = spectreActive;
        prefTrailSpectreVFX.SetActive(true);
        prefStartSpectreVFX.SetActive(true);

        if (filterHabilidad)
        {
            panelHabilidadFilter.enabled = true;
        }
    }

    protected void DesactivarEfecto()
    {
        if (spectreActive)
        {
            modelPlayer.GetComponent<SkinnedMeshRenderer>().enabled = false;
            vfxParticleBack.SetActive(true);
            GetComponent<WeaponController>().ControllerStopFire(); //Dejar de disparar
            float step = speedSpectreBackOrigin * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, newEspectro.transform.position, step);
            GetComponent<Mov>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<WeaponController>().enabled = false;

            // print(Vector3.Distance(this.transform.position, newEspectro.transform.position)); DEBUG!
            //this.transform.localPosition = newEspectro.transform.position;
            //Destroy(newEspectro);

            if (Vector3.Distance(this.transform.position, newEspectro.transform.position) <= spectreDistanceMin)
            {

                GetComponent<Mov>().enabled = true;
                GetComponent<CharacterController>().enabled = true;
                GetComponent<WeaponController>().enabled = true;

                prefTrailSpectreVFX.SetActive(false);
                prefStartSpectreVFX.SetActive(false);

                tiempoCooldownActual = tiempoCooldownMaximo;
                modelPlayer.GetComponent<SkinnedMeshRenderer>().enabled = true;
                vfxParticleBack.SetActive(false);

                if (filterHabilidad)
                {
                    panelHabilidadFilter.enabled = false;
                }

                // StopCoroutine(ParpadeoModel());
                Destroy(newEspectro);
                spectreActive = false;
                isActiveHability = spectreActive; //Variable se utiliza para configuraciones externas

            }
        }

    }

    IEnumerator ParpadeoModel()
    {
        for (int i = 0; i == 1; i++)
        {


            print("apagado " + i);
            new WaitForSeconds(2f);
            print("endWaiting " + i);

        }
        yield return null;
    }

    public override void Activar()
    {

        if (tiempoCooldownActual <= 0)
        {
            if (!isActiveHability)
            {
                if (habilityCostTime)
                {
                    GetComponent<VidaJugador>().HabilityDamage(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
                }

                GameObject newEspectro2 = Instantiate(prefEspectoVFX, this.transform.position, this.transform.rotation);
                newEspectro = newEspectro2;
                //startPositionTransform.position = newEspectro2.transform.position;
                NuevoSonido();
                AplicarEfecto();
                tiempoDuracionActivaActual = 0;
            }
        }
    }

}
