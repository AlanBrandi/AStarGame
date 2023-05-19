using JetBrains.Annotations;
using Script.Money;
using UnityEngine;
using UnityEngine.Search;

namespace Script.Scenes.Tutorial
{
    public enum EnumTutorialState
    {
        Level1,
        Level2,
        Level3,
        Level4,
        ShopTutorial,
        LifeTutorial,
        Sandbox,
        DontChange,
    }
    public class TutorialManager : MonoBehaviour
    {
        private EnumTutorialState _state;
        public EnumTutorialState newState;
        [SerializeField] private string currentState;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        
        public static TutorialManager Instance;
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void Start()
        {
            level1.SetActive(true);
            Currency.Instance.SetMoneyTo(0);
            _state = EnumTutorialState.Level1;
        }
            private void Update()
            {
                currentState = _state.ToString();
            switch (_state)
            {
                case EnumTutorialState.Level1:
                {
                    level1.SetActive(true);
                }
                    break;
                case EnumTutorialState.Level2:
                {
                    level1.SetActive(false);
                    level2.SetActive(true);
                }
                    break;
                case EnumTutorialState.Level3:
                {
                    
                }
                    break;
                case EnumTutorialState.Level4:
                {
                    
                }
                    break;
                case EnumTutorialState.LifeTutorial:
                {
                    
                }
                    break;
                case EnumTutorialState.ShopTutorial:
                {
                    
                }
                    break;
                case EnumTutorialState.Sandbox:
                {
                    
                }
                    break;
                case EnumTutorialState.DontChange:
                {
                    
                }
                    break;
            }
        } 
        public void ChangeState(EnumTutorialState newStateChange)
        {
                _state = newStateChange;
        }

        public void NextDialogue()
        {
            _state = newState;
        }
    }
}
