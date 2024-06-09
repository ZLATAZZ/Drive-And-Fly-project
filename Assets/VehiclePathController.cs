using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePathController : MonoBehaviour
{
    [Header("Points-Anchors for the path")]
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private GameObject pointC;
    [SerializeField] private GameObject pointD;
    [SerializeField] private GameObject pointE;
    [SerializeField] private GameObject pointF;
    [SerializeField] private GameObject pointG;
    [SerializeField] private GameObject pointH;
    [SerializeField] private GameObject pointI;
    [SerializeField] private GameObject pointJ;
    [SerializeField] private GameObject pointK;
    [SerializeField] private GameObject car;

    private float interpolateAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //goes from 1 to 0
        interpolateAmount = (interpolateAmount + Time.deltaTime * 0.05f) % 1;
        car.transform.position = LerpKubick(pointA, pointB, pointC, pointD, pointE, pointF, pointG
            , pointH, pointI, pointJ, pointK, interpolateAmount);
    }

    private Vector3 LerpFourPoints(GameObject a, GameObject b, GameObject c,float interpolationTime)
    {
        Vector3 ab =  Vector3.Lerp(a.transform.position, b.transform.position, interpolationTime);
        Vector3 bc = Vector3.Lerp(b.transform.position, c.transform.position, interpolationTime);

        return Vector3.Lerp(ab, bc, interpolationTime);

    }

    private Vector3 LerpKubick(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g,
         GameObject h, GameObject i, GameObject j, GameObject k, float interpolationTime)
    {
        Vector3 ab_bc = LerpFourPoints(a, b, c, interpolationTime);
        Vector3 bc_cd = LerpFourPoints(b, c, d, interpolationTime);

        Vector3 abcd = Vector3.Lerp(ab_bc, bc_cd, interpolationTime);

        //Continue drawing the whole path, including more and more points each time
        Vector3 abcd_de = Vector3.Lerp(abcd, e.transform.position, interpolationTime);
        Vector3 abcde_ef = Vector3.Lerp(abcd_de, f.transform.position, interpolationTime);
        Vector3 abcdef_fg = Vector3.Lerp(abcde_ef, g.transform.position, interpolationTime);
        Vector3 abcdefg_gh= Vector3.Lerp(abcdef_fg, h.transform.position, interpolationTime);
        Vector3 abcdefgh_hi = Vector3.Lerp(abcdefg_gh, i.transform.position, interpolationTime);
        Vector3 abcdefghi_ij = Vector3.Lerp(abcdefgh_hi, j.transform.position, interpolationTime);
        Vector3 abcdefghij_jk = Vector3.Lerp(abcdefghi_ij, k.transform.position, interpolationTime);
        Vector3 abcdefghijk_ja = Vector3.Lerp(abcdefghij_jk, a.transform.position, interpolationTime);

        //Turn car
        car.transform.LookAt(abcdefghijk_ja, Vector3.zero);

        return abcdefghijk_ja;




    }
}
