using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints HP;
    [HideInInspector]
    public Player Character;
    public Image HPMeterImage;
    public Text HPText;
    float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = Character.maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        if (Character != null)
        {
            HPMeterImage.fillAmount = HP.value / maxHP;
            HPText.text = "HP:" + (HPMeterImage.fillAmount * 100);
        }
    }
}
