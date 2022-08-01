using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var waitForTenSecond = new WaitForSeconds(10f);

        while (true)
        {
            Instantiate(_coinPrefab, transform.position, Quaternion.identity);

            yield return waitForTenSecond;
        }
    }
}
