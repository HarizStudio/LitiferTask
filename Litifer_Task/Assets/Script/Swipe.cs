using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrlBar;    
    float scrlPos=0;
    float[] imagePos;    
    void Start()
    {
        
    }

    void Update()
    {
        imagePos=new float[transform.childCount];
        float dis=1f/(imagePos.Length-1f);
        for(int i=0;i<imagePos.Length;i++)
        {
            imagePos[i]=dis*i;        
        }
        if(Input.GetMouseButton(0))
        {
            scrlPos=scrlBar.GetComponent<Scrollbar>().value;            
        }
        else{
            for(int i=0;i<imagePos.Length;i++)
            {
                if(scrlPos<imagePos[i]*(dis/2)&&scrlPos>imagePos[i]-(dis/2))
                {
                    scrlBar.GetComponent<Scrollbar>().value=Mathf.Lerp(scrlBar.GetComponent<Scrollbar>().value,imagePos[i],0.1f);
                }
            }
        }

        for(int i=0;i<imagePos.Length;i++)
        if(scrlPos<imagePos[i]+(dis/2) && scrlPos>imagePos[i]-(dis/2))
        {
            transform.GetChild(i).localScale=Vector2.Lerp(transform.GetChild(i).localScale,new Vector2(1.2f,1.2f),0.1f);
            for(int j=0;j<imagePos.Length;j++)
            {
                if(j!=i)
                {
                    transform.GetChild(j).localScale=Vector2.Lerp(transform.GetChild(j).localScale,new Vector2(1f,1f),0.1f);
                }
            }
        }
    }
}
