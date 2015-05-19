using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
    private bool _setPosition = false;
    private Vector3 _touchedPosition;

	void Update () {
        if (Input.GetMouseButtonDown(0))
            _setPosition = true;

        if (Input.GetMouseButtonUp(0)) { 
            BounceObject.Instance.GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);
            BounceObject.Instance.GetComponent<Rigidbody>().AddForce((_touchedPosition - BounceObject.Instance.transform.position) * 300);
            _setPosition = false;
        }
            

        if (_setPosition)
        {
            _touchedPosition = Input.mousePosition;
            _touchedPosition.z += transform.position.y;


            _touchedPosition = GetComponent<Camera>().ScreenToWorldPoint(_touchedPosition);

            BounceObject.Instance.GetComponent<LineRenderer>().SetPosition(0, BounceObject.Instance.transform.position);
            BounceObject.Instance.GetComponent<LineRenderer>().SetPosition(1, _touchedPosition);
        }

        RaycastHit hitinfo;
        if (Physics.Linecast(BounceObject.Instance.transform.position, _touchedPosition, out hitinfo))
        {
            Debug.Log(hitinfo.collider.name);
        }



	}
}
