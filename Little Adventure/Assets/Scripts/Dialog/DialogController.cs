using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : Clickable {
    public GameObject UI_Dialog;
    public Replica start_Replica;
    public SimpleEvent OnEndDialog;
    private Replica now_Replica;

    public override float InteractiveDistanse()
    {
        return 1.5f;
    }

    public override void OnInteractive()
    {
        if (enabled)
        {
            now_Replica = start_Replica;
            Player().GetComponent<Player_Controller>().CanControl = false;
            UI_Dialog.SetActive(true);
            UI_Dialog.GetComponent<UI_DialogController>().controller = this;
            UI_Dialog.GetComponent<Animator>().Play("On");
            ShowReplica();
        }
    }
    private void ShowReplica()
    {
        now_Replica.OnStartEvent.Invoke();
        if (now_Replica.ShowOnce) now_Replica.ReplicaActive = false;
        for (int i = 0; i < 6; i++)
        {
            UI_Dialog.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        for (int i = 1; i < 6 ; i++)
        {
            UI_Dialog.transform.GetChild(i).GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        }
        if (now_Replica._Speaker == Replica.Speaker.Player)
        {
            int j = 0;
            for(int i = 0; i < 5&&i<now_Replica.Message.Length; i++)
            {
                if (now_Replica.LastReplica)
                {
                    UI_Dialog.transform.GetChild(i + 1 - j).GetComponentInChildren<UnityEngine.UI.Text>().text = now_Replica.Message[i];
                    UI_Dialog.transform.GetChild(i + 1 - j).GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
                else
                if (now_Replica.Next[i].ReplicaActive)
                {   
                    UI_Dialog.transform.GetChild(i + 1-j).GetComponentInChildren<UnityEngine.UI.Text>().text = now_Replica.Message[i];
                    UI_Dialog.transform.GetChild(i + 1-j).GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
                else j++;
            }
        }
        else
        {
            UI_Dialog.transform.GetChild(0).GetComponentInChildren<UnityEngine.UI.Text>().text = now_Replica.Message[0];
            UI_Dialog.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
    public void NextReplica(int indx)
    {
        now_Replica.OnEndEvent.Invoke();
        if (now_Replica.LastReplica)
        {
            Player().GetComponent<Player_Controller>().CanControl = true;
            UI_Dialog.GetComponent<Animator>().Play("Off");
            if (OnEndDialog!=null) OnEndDialog.Invoke();
        }
        else
        {
            now_Replica = FindNext(indx);
            ShowReplica();
        }
    }
	private Replica FindNext(int indx)
    {
        int j = -1;
        for (int i = 0; i < 5 && i < now_Replica.Message.Length; i++)
        {
            if (now_Replica.Next[i].ReplicaActive)
            {
                j++;
                if (j == indx) return now_Replica.Next[i];
            }
        }
        return null;
    }
    public Replica FindByTag(int tag)
    {
        Replica[] Replics = GetComponents<Replica>();
        for(int i = 0; i < Replics.Length; i++)
        {
            if (Replics[i].ReplicaTag == tag) return Replics[i];
        }
        return null;
    }
    public void ChangeActiveInGroup(int tag)
    {
        Replica[] Replics = GetComponents<Replica>();
        for (int i = 0; i < Replics.Length; i++)
        {
            if (Replics[i].ReplicaTag == tag) Replics[i].ReplicaActive= !Replics[i].ReplicaActive;
        }
    }
}
