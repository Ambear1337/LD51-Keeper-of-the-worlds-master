using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player Instance { get; private set; }
    
    //[SerializeField] private MaterialTintColor materialTintColor;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;


    private void Awake() {
        Instance = this;

        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter(Collider collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            // Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void UseItem(Item item) {
        
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    /*private void DamageFlash() {
        materialTintColor.SetTintColor(new Color(1, 0, 0, 1f));
    }

    public void DamageKnockback(Vector3 knockbackDir, float knockbackDistance) {
        transform.position += knockbackDir * knockbackDistance;
        DamageFlash();
    }

    public void FlashGreen() {
        materialTintColor.SetTintColor(new Color(0, 1, 0, 1));
    }

    public void FlashRed() {
        materialTintColor.SetTintColor(new Color(1, 0, 0, 1));
    }

    public void FlashBlue() {
        materialTintColor.SetTintColor(new Color(0, 0, 1, 1));
    }*/
        
}
