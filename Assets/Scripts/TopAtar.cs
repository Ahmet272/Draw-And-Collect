using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAtar : MonoBehaviour
{
    [SerializeField] private GameObject[] Toplar;
    [SerializeField] private GameObject TopAtarMerkezi;

    int AktifTopIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toplar[AktifTopIndex].transform.position = TopAtarMerkezi.transform.position;
            Toplar[AktifTopIndex].SetActive(true);

            float aci = Random.Range(70f, 110f);
            Vector3 Pos = Quaternion.AngleAxis(aci,Vector3.forward)* Vector3.right;
            Toplar[AktifTopIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(Pos * 800);


            if (AktifTopIndex != Toplar.Length - 1)
            {
                AktifTopIndex++;
            }
            else { AktifTopIndex = 0; }


        }

    }
}
