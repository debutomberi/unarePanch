using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidergage : MonoBehaviour {
    [SerializeField]
    Slider _1pslider;
    [SerializeField]
    Slider _2pslider;
    // Use this for initialization

    int[] deathblowGuage = new int[2] { 0, 0 };
    public int[] DeathblowGuage
    {
        get { return deathblowGuage; }
    }


    void Start () {
        _1pslider = GameObject.Find("slider").GetComponent<Slider>();
        _2pslider = GameObject.Find("slider").GetComponent<Slider>();
    }

    float _gage = 0;

	// Update is called once per frame
	void Update () {
		

	}
    public void GageUp(int count, int pow)
    {
        deathblowGuage[count - 1] += pow;
        if(count == 1)
        {

        }
        if (deathblowGuage[count - 1] >= 100) { deathblowGuage[count - 1] = 100; }
    }
}
