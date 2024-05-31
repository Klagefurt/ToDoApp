using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            if (File.Exists(PATH))
            {
                string data;
                using (var reader = new StreamReader(PATH, false)) 
                { 
                    data = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(data);
            }
            return new BindingList<ToDoModel>();
        }
        public void SaveData(object data)
        {         
            using (var writer = new StreamWriter(PATH, false))
            {
                var jsonData = JsonConvert.SerializeObject(data);
                writer.WriteLine(jsonData); 
            }
        }
    }
}
