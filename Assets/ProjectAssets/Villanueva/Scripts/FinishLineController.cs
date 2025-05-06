using Assets.ProjectAssets.Scripts.GameEvents;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    [SerializeField] private GameEvent onVictory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onVictory.Raise();
        }
    }
}
