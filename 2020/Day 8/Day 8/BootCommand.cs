using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Day_8
{
    public enum CommandType
    {
        NOP,
        ACC,
        JMP
    }


    public class BootCommand
    {
        public CommandType CommandType { get; set; }
        public int Value { get; set; }
    }
}
