using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var data = LoadData(filename).ToList();

            for (var i = 0; i < data.Count; i++)
            {
                var updatedData = data.Select(bc => new BootCommand() { CommandType = bc.CommandType, Value = bc.Value}).ToList();
                Console.WriteLine($"Inspecting commandIndex {i} : ({updatedData[i].CommandType}:{updatedData[i].Value})");

                if (updatedData[i].CommandType == CommandType.JMP)
                {
                    //Console.WriteLine("Changing JMP to NOP");
                    updatedData[i].CommandType = CommandType.NOP;
                    //Console.WriteLine($"Sequence terminates: {DoesBootSequenceTerminate(updatedData)}");
                    DoesBootSequenceTerminate(updatedData);
                }

                else if (updatedData[i].CommandType == CommandType.NOP)
                {
                    //Console.WriteLine("Changing NOP to JMP");
                    updatedData[i].CommandType = CommandType.JMP;
                    //Console.WriteLine($"Sequence terminates: {DoesBootSequenceTerminate(updatedData)}");
                    DoesBootSequenceTerminate(updatedData);
                }
            }
        }

        static bool DoesBootSequenceTerminate(List<BootCommand> bootCommands)
        {
            var commandHistory = new List<int>();
            int accumulator = 0;
            int commandIndex = 0;

            while (true)
            {
                if (commandIndex == bootCommands.Count)
                {
                    Console.WriteLine($"Sequence terminated. Accumulator is {accumulator}");
                    return true;
                }
                
                if (commandIndex < 0 || commandIndex > bootCommands.Count)
                {
                    //Console.WriteLine($"CommandIndex out of bounds: {commandIndex}");
                    return false;
                }

                if (commandHistory.Contains(commandIndex))
                {
                    //Console.WriteLine($"Duplicated command at: {commandIndex}");
                    return false;
                }

                var bootCommand = bootCommands[commandIndex];
                //Console.WriteLine($"Processing {bootCommand.CommandType.ToString()} : {bootCommand.Value.ToString()}. Accumulator is {accumulator}.");
                commandHistory.Add(commandIndex);

                switch (bootCommand.CommandType)
                {
                    case CommandType.ACC:
                        accumulator += bootCommand.Value;
                        commandIndex++;
                        break;
                    case CommandType.JMP:
                        commandIndex += bootCommand.Value;
                        break;
                    case CommandType.NOP:
                        commandIndex++;
                        break;
                }
            }
        }
        
        static List<BootCommand> LoadData(string filename)
        {
            var data = new List<BootCommand>();
            
            string line;

            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    throw new Exception($"Cannot parse BootCommand: {line}");
                }

                if (!Enum.TryParse(parts[0], true, out CommandType commandType))
                {
                    throw new Exception($"Cannot parse BootCommand: {line}");
                }

                if (!int.TryParse(parts[1], out int value))
                {
                    throw new Exception($"Cannot parse BootCommand: {line}");
                }

                var bootCommand = new BootCommand()
                {
                    CommandType = commandType,
                    Value = value
                };
                
                data.Add(bootCommand);
            }

            return data;
        }
    }
}
