using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public HitPoints HP;

    public Inventory inventoryPrefab;
    Inventory inventory;

    public HealthBar healthBarPrefab;
    HealthBar healthBar;

 


    public void Start()
    {
        inventory = Instantiate(inventoryPrefab);
        HP.value = StartingHP;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.Character = this;
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {

                bool shouldDisappear = false;
                print("Hit" + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.IRON:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.WOOD:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.STONE:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.POTION:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    default:
                        break;

                }

                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }

            }
        }
    }

    public bool AdjustHP(int amount)
    {
        if (HP.value < maxHP)
        {
            HP.value += amount;
            print("Adjusted HP by:" + amount + "New Value:" + HP.value);

            return true;
        }
        return false;
    }

    private void OnEnable()
    {
        ResetCharacter();
    }


    public override void ResetCharacter()
    {
        inventory = Instantiate(inventoryPrefab);
        HP.value = StartingHP;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.Character = this;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            HP.value = HP.value - damage;
            if (HP.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void KillCharacter()
    {
        base.KillCharacter();

        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }

   

}
