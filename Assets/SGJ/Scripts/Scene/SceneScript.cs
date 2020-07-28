using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneScript : MonoBehaviour
{
    public RectTransform transitionPanel;

    public AudioSource music;

    public int nextSceneId;

    private const float transitionEnterX = 1000;
    private const float transitionCenterX = 0;
    private const float transitionExitX = -1000;
    private const float transitionTime = 1;
    private const LeanTweenType enterEase = LeanTweenType.easeInExpo;
    private const LeanTweenType exitEase = LeanTweenType.easeOutExpo;

    private const float sceneChangeDelay = 0.1f;

    private const float musicVolumeMod = 0.45f;

    public bool Exiting { get; private set; }

    private float _timer;

    void Start()
    {
        
    }

    public void Update()
    {
        if (!Exiting)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }

        music.volume = Mathf.Min(1, _timer / transitionTime) * musicVolumeMod;

    }

    public void Enter()
    {
        transitionPanel.gameObject.SetActive(true);

        LeanTween.moveX(transitionPanel, transitionEnterX, transitionTime).setEase(enterEase).setFrom(transitionCenterX);
    }

    public void Exit()
    {
        Exiting = true;

        _timer = transitionTime;

        LeanTween.moveX(transitionPanel, transitionCenterX, transitionTime).setEase(exitEase).setFrom(transitionExitX);

        StartCoroutine("NextScene");
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(transitionTime + sceneChangeDelay);

        SceneControl.ChangeScene(nextSceneId);

        yield break;
    }

}
