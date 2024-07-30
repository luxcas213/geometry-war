using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerstats : MonoBehaviour
{
    public bool Puede=true;

    public float vida = 100f;
    public float maxVida = 100f;
    public float daño = 10f;
    public float velocidad = 5f;
    public float regeneracion = 2f;
    public float bulletSpeed = 20f;
    public float shootSpeed = 0.3f;
    public int nivel = 1;
    public float experiencia = 0f;
    public float experienciaNecesaria = 100f;

    public Image barraVida;
    public Image barraExperiencia;
    public Text textoNivel;
    public Text textoVida;

    public GameObject skillPanelPrefab; 
    public Transform skillPanelContainer; 
    public GameObject levelUpUI;

    public GameObject powerUpsObj;

    public int cantidadHabilidades;

    void Start()
    {
        Puede = true;
        vida = maxVida;
        maxVida=100f;
        daño=10f;
        velocidad=5f;
        regeneracion=0f;
        bulletSpeed=20f;
        shootSpeed=0.3f;
        nivel=1;
        experiencia=0f;
        experienciaNecesaria=100f;
        ActualizarUI();
    }

    void FixedUpdate()
    {
        vida += regeneracion * Time.fixedDeltaTime;
        if (vida > maxVida)
        {
            vida = maxVida;
        }
        ActualizarUI();
    }

    void Update()
    {
        if (experiencia >= experienciaNecesaria)
        {
            SubirNivel();
        }
    }

    void SubirNivel()
    {
        nivel++;
        experiencia = 0f;
        experienciaNecesaria *= 1.2f; 

        ActualizarUI();
        seleccionUI();
    }
    void seleccionUI()
    {
        Time.timeScale = 0;
        Puede = false;
        levelUpUI.SetActive(true);
        foreach (Transform child in skillPanelContainer)
        {
            Destroy(child.gameObject);
        }
        powerUpClass[] powerUps = powerUpsObj.GetComponentsInChildren<powerUpClass>();
        for (int i = 0; i < cantidadHabilidades; i++)
        {
            GameObject skillPanelObject = Instantiate(skillPanelPrefab, skillPanelContainer);
            panelcontroller a = skillPanelObject.GetComponent<panelcontroller>();
            TMP_Text skillNameText = a.Name_text;
            TMP_Text skillDescriptionText = a.description_text;
            Image skillIconimage = a.icon_image;
            int j = Random.Range(0, powerUps.Length);
            powerUpClass powerUp = powerUps[j];
            skillDescriptionText.text = powerUp.Description;
            skillNameText.text = powerUp.NameP;
            skillIconimage.sprite = powerUp.icon;
            Button skillButton = skillPanelObject.GetComponentInChildren<Button>();

            if (skillButton != null)
            {
                skillButton.onClick.AddListener(() =>
                {
                    powerUp.use(this);
                    Time.timeScale = 1;
                    Puede = true;
                    levelUpUI.SetActive(false);
                });
            }
        }
    }
    public void GanarExperiencia(float cantidad)
    {
        experiencia += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        barraVida.fillAmount = vida / maxVida;
        barraExperiencia.fillAmount = experiencia / experienciaNecesaria;
        textoNivel.text = "Nivel: " + nivel.ToString();
        textoVida.text = "PV: " + vida.ToString() + " / " + maxVida.ToString();
    }
}
