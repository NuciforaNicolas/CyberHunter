using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
	string gameId = "3678791";
	string rewardId = "rewardedVideo";
	string normalId = "video";
	bool testMode = false;
    [SerializeField] bool inGame;
    [SerializeField] Button myButton;
    [SerializeField] InputField score;
    [SerializeField] int reward;

    void Start()
    {
        if(inGame)
            myButton.interactable = Advertisement.IsReady(rewardId);
        else
            myButton.interactable = Advertisement.IsReady(normalId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowVideo()
    {
        if (inGame)
            Advertisement.Show(rewardId);
        else
            Advertisement.Show(normalId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        myButton.interactable = true;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if(placementId == rewardId){
                int tmp = int.Parse(score.text);
                tmp += reward;
                Debug.Log("Score: " +  tmp);
                score.text = tmp.ToString();
			}
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}

