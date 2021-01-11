using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player
{
    public User user;

    private ID _playerID;

    public PlayerController m_Controller = null;

    public enum ID
    {
        player0 = 0,
        player1 = 1,
    }

    public Player(ID playerID)
    {
        _playerID = playerID;
        user = new User(playerID);
    }

    public ID GetID()
    {
        return _playerID;
    }

    public bool IsID(ID playerID)
    {
        if (_playerID == playerID)
        {
            return true;
        }
        return false;
    }
}

