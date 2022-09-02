﻿using FindMyPG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Service.States
{
    public  interface IStateService
    {
        void InsertState(State state);
        void InsertStates(List<State> states);
        void UpdateState(State state);
        List<State> GetAllStates(); 
        State GetStateById(int id);
        List<State> GetAllActiveStates();
        State GetStateByName(string name);  
    }
}
