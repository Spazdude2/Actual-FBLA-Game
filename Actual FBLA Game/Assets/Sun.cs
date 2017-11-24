using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform sun;
    public float Orbit;
	public float setOrbit;

	// Use this for initialization
	void Start ()
    {
        sun = this.transform;
		setOrbit = Orbit;
	}
	
	// Update is called once per frame
	void Update ()
    {
        sun.Rotate(Orbit, 0, 0);
	}
}
