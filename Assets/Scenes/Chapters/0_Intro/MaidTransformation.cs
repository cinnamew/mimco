using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class MaidTransformation : MonoBehaviour
{
    [SerializeField] int numPic;
    [SerializeField] GameObject nextImage;
    private bool m = false;
    [SerializeField] Flowchart f;
    
    // Start is called before the first frame update
    void Start()
    {
        //print("godobye");
        StartCoroutine(WaitAAH(1.0f));
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private IEnumerator WaitAAH(float waitTime) {
        //print("why hello");
        yield return new WaitForSeconds(waitTime);
        //print("done waiting");
        m = true;
    }

    public void OnClick() {
        print("hi " + m);
        if(m == false) return;
        if(numPic == 3) {
            GetComponent<FadeToBlack>().antiFade();
            WaitAAH(1.0f);
            nextImage.SetActive(false);
            f.ExecuteBlock("after dress");
            return;
        }
        nextImage.SetActive(true);
        //GetComponent<FadeToBlack>().antiFade();
    }
}
