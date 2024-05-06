using System.Collections.Generic;
using SQLite;

namespace Pivculator
{
    public class Repository
    {
        //путь к файлу где будет сохраняться база данных:
        SQLiteConnection conn;
        public Repository(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Item>();//создание таблицы куда будем кидать объекты
        }
        //записывает полученные объекты в список:
        public List<Item> GetItems()
        {
            return conn.Table<Item>().ToList();
        }
        //сохранение записи в бд:
        public int SaveItem(Item item)
        {
            if (item.ID != 0)
            {
                conn.Update(item);
                return item.ID;
            }
            else { return conn.Insert(item); }
        }
        public int DeleteItem(int id)
        {
            return conn.Delete<Item>(id);
        }
    }
}
