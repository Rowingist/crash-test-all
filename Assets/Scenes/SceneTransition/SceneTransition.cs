using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private TMP_Text _loadingPrecentageText;
    [SerializeField] private Image _loadingProgressBar;
    [SerializeField] private Image _blackScreen;

    private static SceneTransition _instance;
    private static bool _shouldPlayOpeningAnimation = false;

    private Animator _componentAnimator;
    private AsyncOperation _loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        _instance._componentAnimator.SetTrigger("sceneClosing");
        _instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        _instance._loadingSceneOperation.allowSceneActivation = false;
        _instance._loadingProgressBar.fillAmount = 0f;
    }

    private void Start()
    {
        _instance = this;

        _componentAnimator = GetComponent<Animator>();

        if (_shouldPlayOpeningAnimation)
        {
            _componentAnimator.SetTrigger("sceneOpening");
            _blackScreen.raycastTarget = false;
            _instance._loadingProgressBar.fillAmount = 1f;
            _shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            _loadingPrecentageText.text = Mathf.RoundToInt(_loadingSceneOperation.progress / 0.9f * 100) + "%";
            _loadingProgressBar.fillAmount = Mathf.Lerp(_loadingProgressBar.fillAmount, _loadingSceneOperation.progress / 0.9f, Time.deltaTime * 5f);
        }
    }

    public void OnAnimationOver()
    {
        _shouldPlayOpeningAnimation = true;
        _loadingSceneOperation.allowSceneActivation = true;
    }

    public void BlockInteraction()
    {
        _blackScreen.raycastTarget = true;
    }

}
