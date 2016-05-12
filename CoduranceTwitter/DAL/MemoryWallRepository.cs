﻿using CoduranceTwitter.Model;
using System;
using System.Collections.Generic;

namespace CoduranceTwitter.DAL
{
    public class MemoryWallRepository : IRepository<Wall>
    {
        private List<Wall> _walls = new List<Wall>();
        
        public void Add(Wall wall)
        {
            _walls.Add(wall);
        }

        public Wall Get(string username)
        {
            return _walls.Find(x => x.Username == username);
        }

        public List<Wall> GetAll(string username)
        {
            return _walls.FindAll(x => x.Username == username);
        }
    }
}