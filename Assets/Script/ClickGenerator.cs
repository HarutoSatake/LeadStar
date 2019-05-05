using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGenerator : MonoBehaviour
{
    [SerializeField] GameObject ClickParticle = null;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            GameObject Particle = Instantiate(ClickParticle) as GameObject;
            Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
            Particle.transform.position = Camera.main.ScreenToWorldPoint(a);
        }
    }

    private void OnDestroy()
    {
        // レンダラのマテリアルを破棄
        var thisRender = this.GetComponent<Renderer>();
        if(thisRender != null && thisRender.materials != null)
        {
            foreach(var m in thisRender.materials)
            {
                DestroyImmediate(m);
            }
        }
    }
}
