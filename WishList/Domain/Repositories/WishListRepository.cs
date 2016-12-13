using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Value_Objects;
using System.Windows;

namespace Domain.Repositories
{
    public sealed class WishListRepository
    {
        private static WishListRepository instance;
        private List<WishList> lists;
        private IFormatter formatter;
        private readonly string filePath;

        internal static WishListRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WishListRepository();
                }
                return instance;
            }
        }

        private WishListRepository()
        {
            lists = new List<WishList>();
            formatter = new BinaryFormatter();
            filePath = @"lists.bin";
            Load();

        }

        public IEnumerable<WishList> GetAll()
        {
            return this.lists;
        }

        public void AddList(WishList list)
        {
            lists.Add(list);
            SaveData();
        }

        public void RemoveList(WishList list)
        {
            lists.Remove(list);
            SaveData();
        }

        public void RemoveListItem(WishList list, Text text)
        {
            var listToRemoveText = lists.Find(x => x.Id == list.Id);
            listToRemoveText.ListItems.Remove(text);
            SaveData();
        }

        public void AddTextItemToList(WishList list, Text text)
        {
                var listToAddText = lists.Find(x => x.Id == list.Id);
                listToAddText.ListItems.Add(text);
            SaveData();
        }

        internal void SaveData()
        {
            try
            {
                using (
                    var streamWriter = new FileStream(this.filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    this.formatter.Serialize(streamWriter, this.lists);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"File missing at {this.filePath}." +
                                                "Failed to save data to file!");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (SerializationException ex)
            {
                throw ex;
            }
            catch (IOException)
            {
                bool checkFile = true;
                while (checkFile)
                {
                    if (IsFileReady(this.filePath))
                    {
                        using (
                            var stream = new FileStream(this.filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            this.formatter.Serialize(stream, this.lists);
                        }
                        checkFile = false;
                    }
                }
            }
        }

        public void Load()
        {
            var lists = new List<WishList>();

            try
            {
                using (
                    var streamReader = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite,
                        FileShare.Read))
                {
                    lists = (List<WishList>)this.formatter.Deserialize(streamReader);
                    this.lists = lists;
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"File missing at {this.filePath}." +
                                                "Load failed!");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (SerializationException ex)
            {
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        private static bool IsFileReady(string sFilename)
        {
            try
            {
                using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (inputStream.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
