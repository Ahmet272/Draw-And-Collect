using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Cizgi;

    public LineRenderer lineRenderer;
    public EdgeCollider2D EdgeCollider;

    public List<Vector2> ParmakPozisyonListesi;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CizgiOlustur();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 ParmakPozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(ParmakPozisyonu , ParmakPozisyonListesi[^1]) > .1f)
            {
                CizgiyiGuncelle(ParmakPozisyonu);
            }
        }
        
    }

    void CizgiOlustur()
    {
        Cizgi = Instantiate(LinePrefab,Vector2.zero,Quaternion.identity);
        lineRenderer = Cizgi.GetComponent<LineRenderer>();
        EdgeCollider = Cizgi.GetComponent<EdgeCollider2D>();
        ParmakPozisyonListesi.Clear();
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ParmakPozisyonListesi.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, ParmakPozisyonListesi[0]);
        lineRenderer.SetPosition(1, ParmakPozisyonListesi[1]);
        EdgeCollider.points = ParmakPozisyonListesi.ToArray();
    }

    void CizgiyiGuncelle(Vector2 GelenParmakPozisyonu)
    {
        ParmakPozisyonListesi.Add(GelenParmakPozisyonu);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, GelenParmakPozisyonu);
        EdgeCollider.points = ParmakPozisyonListesi.ToArray();

    }

}
