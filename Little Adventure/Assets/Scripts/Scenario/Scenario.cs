using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenario : MonoBehaviour {
  
    public void Reload()
    {
        
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    [Header("Main")]
    public GameObject Player;
    [Header("Wizard")]
    public GameObject Wizard;
    public GameObject Teleporter;
    public GameObject Fireball;
    public void WizardGiveFireball()
    {
        GameObject temp = Instantiate(Fireball);
        Player.GetComponent<Inventory>().Put(temp);
        temp.GetComponent<Inventory_Item>().OnUse();
    }
    public void WizardActivateTeleporter()
    {
        Wizard.GetComponent<TargetLook>().enabled = false;
        Wizard.GetComponent<FollowAndAtack>().SetActivBeh(true);
        Wizard.GetComponent<FollowAndAtack>().Others = new List<Collider2D>() { Teleporter.GetComponent<Collider2D>() };

    }
    [Header("Warior")]
    public GameObject Warior;
    public DialogController WarriorDilog;
    public void WariorFirstTalkToPlayer()
    {
        Debug.Log("FirstTalkToPlayer");
        Warior.GetComponent<SmartAtack>().SetActivBeh(false);
        Warior.GetComponent<SmartAtack>()._trigger.TriggerEnable = false;
        Warior.GetComponent<Follow>().SetActivBeh(true);
        Warior.GetComponent<Follow>().Others=new List<Collider2D>() { Player.GetComponent<Collider2D>() };
    }
    public GameObject GATE;
    public GameObject door;
    public GameObject WariorSword;
    public GameObject Hammer;
    public void WariorGoToGate()
    {
        Debug.Log("WariorGoToGate");
        //Warior.GetComponent<SmartAtack>()._trigger.TriggerEnable = true;
        //Warior.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
        //((Colider_Trigger)Warior.GetComponent<SmartAtack>()._trigger).Others = new List<Collider2D>();
        Warior.GetComponent<Follow>().SetActivBeh(false);
        Warior.GetComponent<FollowAndAtack>().SetActivBeh(true);
        Warior.GetComponent<FollowAndAtack>().Others = new List<Collider2D>() { GATE.GetComponent<Collider2D>() };
        Warior.GetComponent<TwoHandsWeapon_Controller>().Del(WariorSword.GetComponent<Weapon>());
        Warior.GetComponent<TargetLook>().Others = new List<Collider2D>() { Player.GetComponent<Collider2D>()};
        GATE.GetComponent<Stats>()._Fraction = Fraction.Bad;
    }
    [SerializeField][HideInInspector]
    private bool ReplicaKey = false;
    public void WarriorGetHammer()
    {
        Player.GetComponent<Inventory>().TakeOne(Hammer);
        Warior.GetComponent<FollowAndAtack>().UseHand = FollowAndAtack.HandsUse.Left;
        Hammer.GetComponent<Weapon>().OnUse(Warior.GetComponent<TwoHandsWeapon_Controller>(), Warior.GetComponent<Human_Body>(), Warior.GetComponent<Stats>());
        GATE.GetComponent<Stats>()._Armor = 0;
    }
    public void OnGateDead()
    {
        Destroy(GATE);
        door.GetComponent<Door>().Set(true);
    }
    public void WarriorDialogStart()
    {
        WarriorDilog.FindByTag(2).ReplicaActive = Player.GetComponent<Inventory>().HaveItem(Hammer);
        if (!ReplicaKey&&Player.GetComponent<Inventory>().CountByItem(System.Type.GetType("Key"))!=-1 )
        {
            WarriorDilog.FindByTag(1).ReplicaActive = true;
            ReplicaKey = true;
        }
    }
    [Header("Warlock")]
    public GameObject Warlock;
    //public GameObject ViewField;
    public void OnEnterTheWarlockRoom()
    {
        Debug.Log("OnEnterTheWarlockRoom");
        Warlock.GetComponent<TargetLook>().SetActivBeh(true);
        Warlock.GetComponent<TargetLook>().Others = new List<Collider2D>() { Player.GetComponent<Collider2D>() };
    }
   
    [Header("Alchimick")]

    public DialogController AlchimicDialog;
    public GameObject AlchimickPotion;
    public Transform AlchimickHand;
    public GameObject GoldKnifePrefab;
    [SerializeField]
    [HideInInspector]
    private bool FindPotion = false;
    [SerializeField]
    [HideInInspector]
    private bool UsePotion = false;
    public void UseAlchimickPotion()
    {
        UsePotion = true;
    }
    public void SetReplicaActiveFindPotion()
    {
        FindPotion = true;

    }
    public void CheckPotionInInventory()
    {
        if(FindPotion)
        if (Player.GetComponent<Inventory>().HaveItem(AlchimickPotion)||UsePotion)
        {
            AlchimicDialog.FindByTag(3).ReplicaActive = true;
            AlchimicDialog.FindByTag(4).ReplicaActive = false;
        }
        else
        {
            AlchimicDialog.FindByTag(3).ReplicaActive = false;
            AlchimicDialog.FindByTag(4).ReplicaActive = true;
        }
        else
        {
            AlchimicDialog.FindByTag(3).ReplicaActive = false;
            AlchimicDialog.FindByTag(4).ReplicaActive = false;
        }
    }
    public void ReturnAlchimickPotion()
    {
        Player.GetComponent<Inventory>().TakeOne(AlchimickPotion);
        AlchimickPotion.SetActive(true);
        AlchimickPotion.transform.SetParent(AlchimickHand);
        AlchimickPotion.transform.localPosition = Vector3.forward/500;
    }
    public void GiveGoldKnife()
    {
        Player.GetComponent<Inventory>().Put(Instantiate(GoldKnifePrefab));
    }
    [Header("EndGame")]
    public HiderController HC;
    public void EndGame()
    {
        enabled = true;
        Warior.GetComponent<TargetLook>().enabled = false;
        HC.Hide(10,100);
    }
    void Update()
    {

        Player.GetComponent<Player_Controller>().CanControl = false;
        Player.GetComponent<BodyController>().Move(new Vector2(-1, 0), 1000, 0);
        Player.GetComponent<BodyController>().SetAngle(180);
        Warior.GetComponent<BodyController>().Move(new Vector2(-1, 0), 1000, 0);
        Warior.GetComponent<BodyController>().SetAngle(180);
    }
}
