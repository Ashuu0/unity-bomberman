using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        Aitem,
        Bitem,
        Citem
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombControllerUI>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombControllerUI>().explosionRadius++;
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<JoystickAnimateV2>().speed++;
                break;
            case ItemType.Aitem:
                player.GetComponent<BombControllerUI>().DBomb();
                break;
            case ItemType.Bitem:
                player.GetComponent<BombControllerUI>().Xdouble();
                player.GetComponent<JoystickAnimateV2>().speed*=2;
                break;
            case ItemType.Citem:
                player.GetComponent<JoystickAnimateV2>().itemstop();
                break;
            
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            OnItemPickup(other.gameObject);
        }
    }
}
