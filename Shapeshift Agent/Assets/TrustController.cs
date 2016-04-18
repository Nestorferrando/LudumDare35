using UnityEngine;
using System.Collections;

public class TrustController : MonoBehaviour
{

    private Target previousTarget;

    private GameObject title;
    private GameObject bar0;
    private GameObject bar1;
    private GameObject bar2;
    private GameObject bar3;
    private GameObject bar4;


    // Use this for initialization
    void Start () {
	    title = GameObject.Find("trustTitle");
        bar0 = GameObject.Find("trustbar0");
        bar1 = GameObject.Find("trustbar1");
        bar2 = GameObject.Find("trustbar2");
        bar3 = GameObject.Find("trustbar3");
        bar4 = GameObject.Find("trustbar4");
    }
	
	// Update is called once per frame
	void Update () {


	    if (previousTarget == null || SingletonData.CurrentTarget != previousTarget)
	    {
	        updateTrustGraphics(SingletonData.CurrentTarget);

	        previousTarget = SingletonData.CurrentTarget;

	    }

	}

    private void updateTrustGraphics(Target currentTarget)
    {
        switch (currentTarget.Trust)

        {
            case TargetTrust.ZERO:
                title.GetComponent<SpriteRenderer>().color = new Color(1f, 0.0f, 0, 1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;

            case TargetTrust.ONE:
                title.GetComponent<SpriteRenderer>().color = new Color(1f, 0.0f, 0, 1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(1f, 0.0f, 0, 1);
                bar1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;

            case TargetTrust.TWO:
                title.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;

            case TargetTrust.THREE:
                title.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar2.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0, 1);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;

            case TargetTrust.FOUR:
                title.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;

            case TargetTrust.FIVE:
                title.GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
                bar0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar3.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                bar4.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                break;


        }
    }
}
