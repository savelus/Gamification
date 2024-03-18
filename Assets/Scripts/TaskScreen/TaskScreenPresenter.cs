using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace TaskScreen 
{
    public class TaskScreenPresenter : BasePresenter<TaskScreenView> 
    {
        private const int StartSpawnTask = 5;

        private readonly Queue<Task> _notUsableTask = new();
        private readonly List<Task> _viewedTasks = new();
        
        public TaskScreenPresenter(TaskScreenView screenView) 
        {
            InitializePresenter(screenView);
        }
        protected override void InitializeView() 
        {
            ClearViewedTasks();
            SpawnTasks(5);

            SetupExampleTasks();
        }

        private void SetupExampleTasks() 
        {
            AddTask("Почини компъютер");
            AddTask("Напиши задачу");
            AddTask("Реши задачу");
            AddTask("Сделай отчет");
            AddTask("Отдохни");
        }

        public void AddTask(string taskText) 
        {
            if(_notUsableTask.Count == 0) 
            {
                SpawnOneTask();
            }

            var task = _notUsableTask.Dequeue();
            _viewedTasks.Add(task);
            task.InitializeTask(Color.red, Color.green, taskText, TaskStateChanged);
        }
        
        private void SpawnTasks(int tasksCount) 
        {
            _notUsableTask.Clear();
            
            for (int i = 0; i < tasksCount; i++) 
            {
                SpawnOneTask();
            }
        }

        private void SpawnOneTask() 
        {
            _notUsableTask.Enqueue(View.SpawnTask());
        }

        private void ClearViewedTasks() 
        {
            foreach (var task in _viewedTasks) 
            {
                View.DeleteTask(task);
            }
            _viewedTasks.Clear();
        }

        private void TaskStateChanged(Task task) 
        {
            if (task.TaskComplete) CompleteTask(task);
            UnCompleteTask(task);
        }

        private void UnCompleteTask(Task task) 
        {
            task.UnCompleteTask();
        }

        private void CompleteTask(Task task) 
        {
            task.CompleteTask();
        }
    }
}