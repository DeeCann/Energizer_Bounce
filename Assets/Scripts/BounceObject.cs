using UnityEngine;
using System.Collections;

public class BounceObject : MonoBehaviour {

	private static BounceObject _instance = null;

    public static BounceObject Instance {
        get {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType(typeof(BounceObject)) as BounceObject;

            return _instance;
        }
    }

    void Awake() {
        _instance = this;
    }
}
