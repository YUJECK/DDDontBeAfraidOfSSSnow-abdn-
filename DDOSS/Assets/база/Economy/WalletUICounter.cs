using TMPro;
using UnityEngine;
using VContainer;

namespace база.Economy
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class WalletUICounter : MonoBehaviour
    {
        private TMP_Text _text;
        private Wallet _wallet;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
            wallet.OnBalanceChanged += UpdateCounter;
        }
        
        private void UpdateCounter(int arg1, int arg2)
        {
            _text.text = arg2.ToString();
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = _wallet.CurrentBalance.ToString();
        }
    }
}
