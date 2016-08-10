using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using DB.BusinessLayer;
using System.Collections.Generic;
using DB.BusinessLayer.Managers;
using System.IO;
using Android.Util;
using SQLite; 

namespace DB.Droid
{  

	[Activity (Label = "DB.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        private List<Task> tasks; 
       
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var sqliteFilename = "TaskDB.db3";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            Log.Debug("Debug", "path: " + path);
             

            TaskManager.SetPath(path);


            tasks = new List<Task>();
            tasks.Add(new Task("task1","task1 notes", true, true, true, true)); 
            tasks.Add(new Task("task2","task1 notes", true, true, true, true)); 
            tasks.Add(new Task("task3","task1 notes", true, true, true, true)); 
            tasks.Add(new Task("task4","task1 notes", true, true, true, true)); 
            tasks.Add(new Task("task5","task1 notes", true, true, true, true)); 
            tasks.Add(new Task("task6","task1 notes", true, true, true, true));

            List<int> ids = new List<int>();
            foreach(Task task in tasks)
            {
                var id = TaskManager.SaveTask(task);
                Log.Debug("Debug", "Added task, id: " + id);
                ids.Add(id);
            }

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.myButton);

            var textID = FindViewById<TextView>(Resource.Id.textViewID);
            var textTitle = FindViewById<TextView>(Resource.Id.textViewTitle);
            var textTime = FindViewById<TextView>(Resource.Id.textViewTime); 

            button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);

                //textTitle.Text = tasks[count % tasks.Count].Title;
                //textTime.Text = tasks[count % tasks.Count].Alarm.Time.ToString();
                var task = TaskManager.GetTask(ids[count%ids.Count]);
                textID.Text = task.ID.ToString() ;
                textTitle.Text = task.ID.ToString() ;
                textTime.Text = task.Alarm.Time.ToString() ; 
            };
             

        }
	} 
}


