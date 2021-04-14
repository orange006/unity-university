using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabController : MonoBehaviour
{
    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "42";
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        StartCloudHelloWorld();
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Hello World!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private static void StartCloudHelloWorld()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "helloWorld"
        }, OnCloudHelloWorld, OnError);
    }

    private static void OnCloudHelloWorld(ExecuteCloudScriptResult result)
    {
        Debug.Log(result.FunctionResult.ToString());
    }

    private static void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
