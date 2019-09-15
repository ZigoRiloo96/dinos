
using System.Collections.Generic;
using UnityEngine.Events;

namespace riloo
{

    public class Task
    {
        private UnityAction onDoneAction;
        private UnityAction<Task> taskAction;
        public bool complete = false;
        public float timer = 1.0f;
        public int index = 0;

        public Task(UnityAction _onDoneAction, UnityAction<Task> _taskAction, int _index = 0, float _timer = 1.0f)
        {
            Init(_onDoneAction, _taskAction, _index, _timer);
        }

        private void Init(UnityAction _onDoneAction, UnityAction<Task> _taskAction, int _index, float _timer)
        {
            onDoneAction = _onDoneAction;

            taskAction = _taskAction;

            timer = _timer;

            index = _index;
        }

        public void Run()
        {
            taskAction.Invoke(this);

            if (complete)
            {
                onDoneAction.Invoke();
            }
        }
    }

    public class TaskManagerScript : Singelton<TaskManagerScript>
    {
        private static Queue<Task> tasks = new Queue<Task>();

        private static Task currentTask;

        private static bool isRun = false;

        private void Update()
        {
            if (!isRun) return;

            currentTask.Run();
        }

        public static void AddTask(UnityAction<Task> _taskAction, int _index = 0, float _timer = 1.0f)
        {
            tasks.Enqueue(new Task(OnTaskDone, _taskAction, _index, _timer));

            if (isRun == false)
            {
                currentTask = tasks.Dequeue();
                isRun = true;
            }
        }

        private static void OnTaskDone()
        {
            if (tasks.Count == 0)
            {
                isRun = false;
                OnTasksComplete();
                return;
            }

            currentTask = tasks.Dequeue();
        }

        private static void OnTasksComplete()
        {
            isRun = false;
        }
    }

}
