using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour {
    [SerializeField] float health;
    [SerializeField] float speed;

    [HideInInspector] public UnityEvent onStatsChanged;


    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;
            onStatsChanged.Invoke();
        }
    }
    public float Health {
        get {
            return health;
        }
        set {
            health = value;
            onStatsChanged.Invoke();
        }
    }
}
