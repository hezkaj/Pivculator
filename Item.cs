using SQLite;

namespace Pivculator
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }

        public string Name { get; set; }//без изменений
        public float Alcho { get; set; }//получать деленой на цена деленую на объем
        public float Coint { get; set; }//получать деленой на объем
        public int Slide { get; set; }//получать деленой на цена деленую на объем
    }
}
