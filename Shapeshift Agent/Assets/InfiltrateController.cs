using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InfiltrateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameObject.Find("black_layer").GetComponent<BlackLayerController>().LayerActive = true;
        Invoke("goToScene3",3.0f);
       
    }

    private void goToScene3()
    {
        SceneManager.LoadScene("gameScene3");
    }

}
