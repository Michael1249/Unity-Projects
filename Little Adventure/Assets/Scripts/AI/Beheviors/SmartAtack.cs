using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartAtack : FollowAndAtack {
    float time;
    [Header("_General_")]
    public AtackState _State=AtackState.Stay;
    public float MinRange=0;
    public int MinRangeState=3;
    public float MaxRange=8;
    public int MaxRangeState=2;
    public List<StateOpt> BeheviorOpt;
    [Header("_Stay_")]

    [Header("_Move_")]
    [SerializeField]
    protected float MoveAngleWindow;

    [Header("_Atack_")]
    [SerializeField]
    protected float AtackAngle;
    [SerializeField]
    protected float AtackDeltaAngle;

    [Header("_Back_")]
    [SerializeField]
    protected float BackAngle;
    [SerializeField]
    protected float BackDeltaAngle;

    
    public SimpleEvent OnHitEvent;

    void Start () {
        GetComponent<Stats>().OnHitEvent.AddListener(OnHitEvent.Invoke);
        SetTime(0);
	}
    private void SetTime(int state)
    {
        time = BeheviorOpt[state].Time + Random.Range(-BeheviorOpt[state].DeltaTime, BeheviorOpt[state].DeltaTime);
    }
    [System.Serializable]
    public class SetStateArgs
    {
       public int state;
       public float HealthMin;
       public float HealthMax;
    }
public void SetState(int Arg)
    {
        if((int)_State!=Arg)
        {
            _State = (AtackState)Arg;
            InitState();
            SetTime(Arg);
        }
    }
	protected override void Update () {
        float range = Range();
        if (range < MinRange)
            SetState(MinRangeState);
        else if (range > MaxRange&&_State!=AtackState.Back) 
            SetState(MaxRangeState);
        
        {
            switch (_State)
            {
                case AtackState.Stay: { Look(); } break;
                case AtackState.Atack: { base.Update(); } break;
                default: { Look(); Move(); } break;
            }
            time -= Time.deltaTime;
            if (time < 0)
            {
                NextState();
                InitState();
                SetTime((int)_State);
            }
        }
      
	}
    private void NextState()
    {
        float Max = 0;
        int N=0;
        int state = (int)_State;
        for(int i = 0; i < 4; i++)
        {
             float value=Random.value*BeheviorOpt[state].Preorities[i];
            if (value > Max) { Max = value;N = i; }
        }
        _State =(AtackState)N;
    }
    private void InitState()
    {
        switch (_State)
        {
            case AtackState.Stay: { AngleDelta = 0;  } break;
            case AtackState.Move: { MoveAngle = Random.value > 0.5 ? 90 : -90 + Random.Range(-MoveAngleWindow, MoveAngleWindow);  } break;
            case AtackState.Atack: { MoveAngle = AtackAngle+Random.Range(-AtackDeltaAngle,AtackDeltaAngle); } break;
            case AtackState.Back: { MoveAngle = BackAngle + Random.Range(-BackDeltaAngle, BackDeltaAngle); } break;
        }
        AngleDelta = _State == AtackState.Back ? 180 : 0;
    }
    public enum AtackState
    {
        Stay,
        Move,
        Atack,
        Back
    }
}
[System.Serializable]
public class StateOpt
{
    public float Time;
    public float DeltaTime;
    public float[] Preorities;
}
