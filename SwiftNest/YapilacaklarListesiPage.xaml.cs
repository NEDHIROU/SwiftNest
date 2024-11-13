using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace SwiftNest
{
    public partial class YapilacaklarListesiPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public YapilacaklarListesiPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>(); // Initialize the tasks list
            ToDoListView.ItemsSource = Tasks; // Link the ListView with the tasks
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            string taskName = await DisplayPromptAsync("Yeni Görev", "Görevinizi girin:");
            if (!string.IsNullOrEmpty(taskName))
            {
                Tasks.Insert(0, new TaskItem { TaskName = taskName, IsCompleted = false });
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as TaskItem;
            if (selectedItem != null)
            {
                selectedItem.TaskName = selectedItem.IsCompleted ? $"✓ {selectedItem.TaskName}" : selectedItem.TaskName.Replace("✓ ", "");
            }
        }

        private async void OnEditTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as TaskItem;
            if (task != null)
            {
                string newTaskName = await DisplayPromptAsync("Düzenle", "Görevinizi güncelleyin:", initialValue: task.TaskName);
                if (!string.IsNullOrEmpty(newTaskName))
                {
                    task.TaskName = newTaskName;
                }
            }
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as TaskItem;
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            DisplayAlert("Başarıyla Kaydedildi", "Görevler başarıyla kaydedildi.", "Tamam");
        }
    }

    public class TaskItem
    {
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
