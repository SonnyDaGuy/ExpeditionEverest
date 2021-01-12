using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode; //temp

    [SerializeField] private GameObject _explorer, _dog;

    [SerializeField] private Transform _explorerSpawn, _dogSpawn; 

    private void Awake()
    {
        CurrentGameMode.SetGameMode(_gameMode); //temp

        List<Player> players = InstantiatePlayers(_gameMode);
        GameObject explorer = null;
        if(CurrentGameMode.gameMode == GameMode.SinglePlayer)
        {
            explorer = SpawnCharacter(_explorer, players[1], CharacterType.Explorer, _explorerSpawn);
            SpawnCharacter(_dog, players[0], CharacterType.Dog, _dogSpawn);
        }
        else if (CurrentGameMode.gameMode == GameMode.LocalCoop)
        {
            explorer = SpawnCharacter(_explorer, players[1], CharacterType.Explorer, _explorerSpawn);
            SpawnCharacter(_dog, players[2], CharacterType.Dog, _dogSpawn);
        }
        FindObjectOfType<CameraRotator>().SetPlayers(players);
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
    
    private GameObject SpawnCharacter(GameObject prefab, Player player, CharacterType characterType, Transform spawn)
    {
        GameObject character = Instantiate(prefab, spawn.position, prefab.transform.rotation);
        CharacterController characterController = character.GetComponent<CharacterController>();
        characterController.SetPlayer(player);
        characterController.SetCharacterType(characterType);
        return character;
    }
}
