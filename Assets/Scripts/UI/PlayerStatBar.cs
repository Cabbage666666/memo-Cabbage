using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public Image healthImage;
    public Image healthDelayImage;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(healthDelayImage.fillAmount > healthImage.fillAmount)
        {
            healthDelayImage.fillAmount -= Time.deltaTime*0.3f;
        }
    }

    /// <summary>
    /// 接受Health的变更百分比
    /// </summary>
    /// <param name="persentage">百分比:Current/Max</param>
    public void OnHwalthChanged(float persentage)
    {
        healthImage.fillAmount = persentage;
    }

}
