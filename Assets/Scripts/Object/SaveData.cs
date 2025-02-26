using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Scripts.Object
{
    public class SaveData
    {

    }
    public class PlayerData : SaveData
    {
        public float posX, posY;
    }
    public class BagData: SaveData
    {
        public List<ItemData> items;
    }
    public class ItemData: SaveData
    {
        public string name;
        public int count;
    }
}