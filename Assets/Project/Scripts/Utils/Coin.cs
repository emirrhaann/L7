using Project.Scripts.Utils;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private OnTriggers _onTriggers;
    private void Start()
    {
        _onTriggers = FindObjectOfType<OnTriggers>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _onTriggers.coincount++;
        _onTriggers.cointext.text = _onTriggers.coincount + "";
    }
}
