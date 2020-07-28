using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningRoomScene : SceneScript
{
    public NPCConversation conv;

    private bool _ended;
    
    void Start()
    {
        Enter();

        StartCoroutine("Begin");
    }

    void Update()
    {
        base.Update();

        if (_ended && !Exiting && !ConversationManager.Instance.IsConversationActive)
        {
            Exit();
        }

    }

    public void OnConversationEnded()
    {
        _ended = true;
    }

    private IEnumerator Begin()
    {
        yield return new WaitForSeconds(1);

        ConversationManager.Instance.StartConversation(conv);
    }
}
