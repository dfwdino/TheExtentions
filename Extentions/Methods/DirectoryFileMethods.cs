using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDN.Extensions

{
    public static class DirectoryExtensions
    {
        /// <summary>
        /// Used VB to move the directory to the recycle bin.
        /// </summary>
        /// <param name="DirectoryLocation"></param>
        public static void MoveToRecycleBin(this DirectoryInfo DirectoryLocation)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(DirectoryLocation.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }

        public static void CheckPath(string DirectoryPath, bool CreatePath = true)
        {
            if (!Directory.Exists(Path.GetDirectoryName(DirectoryPath)) && CreatePath.Equals(true))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DirectoryPath));
            }
        }


    }


    public static class FileExtensions
    {
        public static void MoveTo(this string OldLocationFullName, string NewLocation, bool overwrite = false)
        {

            FileInfo fi = new FileInfo(OldLocationFullName);

            NewLocation = OldLocationFullName.Replace(fi.DirectoryName, NewLocation);

            DirectoryInfo MoveToLocation = new DirectoryInfo(NewLocation);

            if(MoveToLocation.Exists.Equals(false))
            {
                MoveToLocation.Create();
            }


            if (File.Exists(NewLocation) == true && overwrite == false)
            {
                string ThisIsNowNow = DateTime.Now.ToFileTimeUtc().ToString();

                NewLocation = NewLocation.Replace(".", $"_{ThisIsNowNow}.");
                
            }

            File.Move(OldLocationFullName.ToString(), NewLocation);


        }

        public static void MoveTo(this FileInfo OldLocationFullName, string NewLocation, bool overwrite = false)
        {

            MoveTo(OldLocationFullName.FullName,NewLocation,overwrite);

        }

        /// <summary>
        /// Used VB to move the file to the recycle bin.
        /// </summary>
        /// <param name="FileLocation"></param>
        public static void MoveToRecycleBin(this FileInfo FileLocation)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(FileLocation.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
    }

}
