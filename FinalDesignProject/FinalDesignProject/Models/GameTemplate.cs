using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FinalDesignProject.Models
{
    abstract class GameTemplate
    {
        private string saveName;

        public void SaveGame()
        {
            do {
                Console.WriteLine("Please Enter a Save Name: ");
                saveName = Console.ReadLine();
            } while (string.IsNullOrEmpty(saveName));


			getPlayerInfo();
            getCurrentPlayer();
            getOtherSaveInfo();

            SaveFile.Instance.SaveToJson(this.ToString(), saveName);
		}

        protected abstract void getPlayerInfo();

        protected abstract void getCurrentPlayer();

        protected abstract void getOtherSaveInfo();
    }
} 