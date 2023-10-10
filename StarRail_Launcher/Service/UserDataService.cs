﻿using StarRail_Launcher.Models;
using StarRail_Launcher.Service.IService;
using System.Collections.Generic;
using System.IO;

namespace StarRail_Launcher.Service
{
    public class UserDataService : IUserDataService
    {
        /// <summary>
        /// 读取用户数据列表
        /// </summary>
        /// <returns></returns>
        public List<UserListModel> ReadUserList()
        {
            List<UserListModel> list = new();
            DirectoryInfo TheFolder = new(@"UserData");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                list.Add(new UserListModel { UserName = NextFile.Name });
            }
            return list;
        }
    }
}