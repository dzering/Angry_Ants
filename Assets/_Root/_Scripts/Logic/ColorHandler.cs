using _Root._Scripts.Data;
using UnityEngine;

namespace _Root._Scripts.Logic
{
    public class ColorHandler : MonoBehaviour
    {
        public Renderer rendererObject;
        public int tintColor = 0;

        private void Start()
        {
            if (rendererObject == null)
            {
                rendererObject = GetComponent<Renderer>();
            }

            if (GameDataSingleton.instance == null)
                return;

            var teamColor = GameDataSingleton.instance.teamColor;

            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetColor("_Color", teamColor);
            rendererObject.SetPropertyBlock(propertyBlock, tintColor);
        }
    }
}