namespace AirConditionerTestingSystem.Core.Commands
{
    /* Bug in in splitting command parameters -> split should start from the next index
    Other potentital problem is when command doesn't have a space ' ' between 
    the command name and the first bracket of the parameters body
    Changing code to split from the first bracket */
    using System;
    using System.Collections.Generic;
    using Common;

    public class Command : ICommand
    {
        public Command(string line)
        {
            this.InitFromLine(line);
        }

        public CommandName Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        private void InitFromLine(string line)
        {
            string nameAsString = line
                .Substring(0, line.IndexOf('('))
                .Trim();

            CommandName name;
            // User friendly - ignores case
            if (!Enum.TryParse(
                value: nameAsString, ignoreCase: true, result: out name))
            {
                throw new InvalidOperationException(StatusMessages.InvalidCommand);
            }

            this.Name = name;

            try
            {
                this.Parameters = line.Substring(line.IndexOf('('))
                .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException(
                    StatusMessages.InvalidCommand, ex);
            }
        }
    }
}
