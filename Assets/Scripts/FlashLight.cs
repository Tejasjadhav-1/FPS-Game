using TMPro;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Light flashLight;
    [SerializeField] int battery = 100;
    [SerializeField] TMP_Text batteryText;
    float batteryTimer = 0f;


    private void Start()
    {
        flashLight.enabled = false;
        UpdateBatteryUI();
    }

    private void Update()
    {
        batteryTimer += Time.deltaTime;
        if(flashLight.enabled && batteryTimer >= 1f)
        {
            battery -= 1;
            UpdateBatteryUI();
            batteryTimer = 0f;
            if(battery <= 0)
            {
                flashLight.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && battery >= 1)
        {
            flashLight.enabled = !flashLight.enabled;
        }


    }
    private void UpdateBatteryUI()
    {
        batteryText.text = $"Battery: {battery}%";
    }
}
