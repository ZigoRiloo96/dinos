
using UnityEngine;
using UnityEngine.UI;

namespace riloo
{

    public class LogoScript : MonoBehaviour
    {
        public GameObject rootObject;

        public Image BackgroundImage;

        public Image BackgroundCoverImage;

        public Image LogoImage;

        public Image[] CatFootsImages;

        public AudioSource audioSorce;

        public AudioSource audioSorce2;

        public AudioClip mainClip;

        public AudioClip meowClip;

        private void OnLoadIsDone()
        {
            audioSorce2.PlayOneShot(mainClip);

            Tasks();
        }

        private void Start()
        {
            Time.timeScale = 0f;
            SceneLoaderScript.LoadScene(1, OnLoadIsDone);
        }

        private void Tasks()
        {
            TaskManagerScript.AddTask(
            delegate (Task task)
            {
                Color c = BackgroundCoverImage.color;

                c.a -= Time.unscaledDeltaTime * 1f;

                if (c.a < 0f)
                {
                    c.a = 0f;
                    BackgroundCoverImage.color = c;
                    task.complete = true;
                    return;
                }

                BackgroundCoverImage.color = c;
            });

            TaskManagerScript.AddTask(
            delegate (Task task)
            {
                Color c = LogoImage.color;

                c.a += Time.unscaledDeltaTime * 1f;

                if (c.a > 1f)
                {
                    c.a = 1f;
                    LogoImage.color = c;
                    task.complete = true;
                    return;
                }

                LogoImage.color = c;
            });

            for (int i = 0; i < 3; i++)
            {
                TaskManagerScript.AddTask(
                delegate (Task task)
                {
                    Color c = CatFootsImages[task.index].color;

                    c.a += Time.unscaledDeltaTime * 1.5f;

                    if (c.a > 1f)
                    {
                        c.a = 1f;
                        task.complete = true;
                        CatFootsImages[task.index].color = c;
                        return;
                    }

                    CatFootsImages[task.index].color = c;
                }, i);
            }

            TaskManagerScript.AddTask(
            delegate (Task task)
            {
                task.timer -= Time.unscaledDeltaTime;

                if (task.timer < 0f)
                {
                    task.timer = 0f;
                    audioSorce.PlayOneShot(meowClip);
                    task.complete = true;
                }
            }, _timer: 0.25f);

            TaskManagerScript.AddTask(
            delegate (Task task)
            {
                task.timer -= Time.unscaledDeltaTime;

                if (task.timer < 0f)
                {
                    task.timer = 0f;
                    task.complete = true;
                }
            }, _timer: 0.25f);

            for (int i = 3; i < CatFootsImages.Length; i++)
            {
                TaskManagerScript.AddTask(
                delegate (Task task)
                {
                    Color c = CatFootsImages[task.index].color;

                    c.a += Time.unscaledDeltaTime * 2.5f;

                    if (c.a > 1f)
                    {
                        c.a = 1f;
                        task.complete = true;
                        CatFootsImages[task.index].color = c;
                        return;
                    }

                    CatFootsImages[task.index].color = c;
                }, i);
            }

            TaskManagerScript.AddTask(
            delegate (Task task)
            {
                Color c = BackgroundImage.color;

                c.a -= Time.unscaledDeltaTime * 1f;


                if (c.a < 0f)
                {
                    c.a = 0f;

                    //BackgroundCoverImage.color = c;

                    BackgroundImage.color = c;

                    LogoImage.color = c;

                    task.complete = true;

                    Time.timeScale = 1f;

                    Destroy(rootObject);

                    return;
                }

                //BackgroundCoverImage.color = c;

                BackgroundImage.color = c;

                LogoImage.color = c;

                for (int i = 0; i < CatFootsImages.Length; i++)
                {
                    CatFootsImages[i].color = c;
                }

            });
        }
    }

}