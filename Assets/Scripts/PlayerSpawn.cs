using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode; //temp

    [SerializeField] private GameObject _explorer, _dog;

    private void Awake()
    {
        CurrentGameMode.SetGameMode(_gameMode); //temp

        List<Player> players = InstantiatePlayers(_gameMode);
        if(CurrentGameMode.gameMode == GameMode.SinglePlayer)
        {
            Debug.Log("ISINDE SINGLE");
            AssignPlayerToCharacter(players[1], _explorer);
            AssignPlayerToCharacter(players[0], _dog);
        }
        else if (CurrentGameMode.gameMode == GameMode.LocalCoop)
        {
            AssignPlayerToCharacter(players[1], _explorer);
            AssignPlayerToCharacter(players[2], _dog);
        }
    }

    private List<Player> InstantiatePlayers(GameMode gameMode)
    {
        Debug.Log("Instantiating players");
        List<Player> players = new List<Player>();
        for (int i = 0; i < ((int)CurrentGameMode.gameMode + 1); i++)
        {
            Player player = new Player((Player.ID)i);
            players.Add(player);
        }
        return players;
    }
    
    private GameObject AssignPlayerToCharacter(Player player, GameObject character)
    {
        Debug.Log("ASSIGNING: " + player.GetID() + " TO: " + character.name);
        CharacterController characterController = character.GetComponent<CharacterController>();
        characterController.SetPlayer(player);
        return character;
    }
}
