using UnityEngine;

namespace cakeslice
{
    public class Outlining : MonoBehaviour
    {
        public Outline[] oL;

        private void Start()
        {
            oL[0] = GetComponent<Outline>();
        }

        private void OnMouseEnter()
        {
            for(int i = 0; i < oL.Length; i++)
            {
                oL[i].eraseRenderer = false;
            }
        }

        private void OnMouseExit()
        {
            for(int i = 0; i < oL.Length; i++)
            {
                oL[i].eraseRenderer = true;
            }
        }
    }
}