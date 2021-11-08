using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] GameObject[] FirDestroy;
    [SerializeField] GameObject NormalFir;
    [SerializeField] GameObject FirGO;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(DestroyCollider());
            NormalFir.SetActive(false);
            for (int i = 0; i < FirDestroy.Length; i++)
            {
                FirDestroy[i].SetActive(true);
            }
            Destroy(FirGO, 4f);
        }
    }

    IEnumerator DestroyCollider()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < FirDestroy.Length; i++)
        {
            FirDestroy[i].GetComponent<MeshCollider>().enabled = false;
        }
    }
}
