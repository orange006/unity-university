using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.UI;

public class GetConfig : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    private string message;
    private int number;

    [SerializeField] private Text messageText;
    [SerializeField] private Text numberText;

    private void Awake()
    {
        ConfigManager.FetchCompleted += SetValues;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>
                 (new userAttributes(), new appAttributes());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ConfigManager.FetchConfigs<userAttributes, appAttributes>(
                          new userAttributes(), new appAttributes());

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void SetValues(ConfigResponse response)
    {
        message = ConfigManager.appConfig.GetString("TextMessage");
        number = ConfigManager.appConfig.GetInt("RemoteNumber");

        messageText.text = message;
        numberText.text = "Remote Number is: " + number.ToString();
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetValues;
    }
}
