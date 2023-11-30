using MVVM.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        IScoreViewModel scoreViewModel;
        string startText;

        private void Start()
        {
            startText = scoreText.text;
        }
        public void Initialize(IScoreViewModel scoreViewModel)
        {
            this.scoreViewModel = scoreViewModel;
            scoreViewModel.OnChange += TextUpdate;
        }

        public void UpdateChanges(int count)
        {
            scoreViewModel.UpdateModel(count);
        }

        void TextUpdate(int count)
        {
            scoreText.text = startText + count;
        }

        ~ScoreView()
        {
            scoreViewModel.OnChange -= TextUpdate;
        }
    }
}
