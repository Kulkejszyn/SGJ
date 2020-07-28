using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpeningHallScene : SceneScript
{

    private bool[] _talkedTo = new bool[5]; // every talkable character has his id
    // 0 - Marlena
    // 1 - Jacek
    // 2 - Ichii & Pichii
    // 3 - Edek
    // 4 - Eryk
    private const int talksAllowed = 3;

    private bool _ended;

    void Start()
    {
        Enter();
    }


    void Update()
    {
        base.Update();

        if (_ended && !Exiting && !ConversationManager.Instance.IsConversationActive)
        {
            Exit();
        }
    }

    private void CheckNumberOfTalks()
    {
        if(_talkedTo.Count(x => x == true) >= talksAllowed)
        {
            _ended = true;
        }
    }

    public void OnCharacterTalkedTo(int id)
    {
        _talkedTo[id] = true;

        CheckNumberOfTalks();
    }

    public void OnMarlenaTalkedTo()
    {
        _talkedTo[0] = true;

        CheckNumberOfTalks();
    }
}
