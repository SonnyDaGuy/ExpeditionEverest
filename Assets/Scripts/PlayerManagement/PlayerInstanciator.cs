using UnityEngine;

public class PlayerInstanciator : MonoBehaviour
{
    [SerializeField] private int _numberOfPlayers;
    
    void Awake()
    {
        Debug.Log("Instantiating players");
        Players.Refresh();
        {
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                Player player = new Player((Player.ID)i);
                Players.AddPlayer(player);
            }
        }
    }
}
