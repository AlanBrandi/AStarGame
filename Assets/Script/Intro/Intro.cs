using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Intro
{
    public class Intro : MonoBehaviour
    {
        // Animator camera e canvas.
        [SerializeField] Animator animCamera;
        [SerializeField] Animator animCanvas;

        //Bool first sound.
        private bool _playedIntroSoundFX = false;

        //Canvas Audio pressed button.
        [SerializeField] AudioSource _soundFx;

        [SerializeField] private string _scene;

        void Update()
        {
            if (Input.anyKeyDown)
            {
                animCamera.SetTrigger("Foward");
                animCanvas.SetTrigger("Menu"); 
                if (!_playedIntroSoundFX)
                {
                    PlaySound();
                    _playedIntroSoundFX = true;
                }
            }
        }
        public void PlaySound()
        {
            _soundFx.Play();
        }
        public void LoadSceneWithDelay(float delay)
        {
            Invoke(nameof(LoadScene), delay);
        }
        private void LoadScene()
        {
            SceneManager.LoadScene(_scene);
        }

        public void ExitWithDelay(float delay)
        {
            Invoke(nameof(Exit),delay);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
