using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace TaskScreen 
{
    public class TaskScreenView : BaseView 
    {

        [SerializeField] private Task taskPrefab;

        [SerializeField] private Transform taskRoot;

        public Task SpawnTask() 
        {
            var spawnedTask = Instantiate(taskPrefab, taskRoot); 
            //TODO Почитать про фабрику и унести спавн объектов в отдельную историю
            spawnedTask.HideTask();
            return spawnedTask;
        }

        public void DeleteTask(Task task) 
        {
            Destroy(task);
        }
    }
}