using System;
using System.Collections.Generic;

namespace MoviesDB;

public partial class Director
{
    public int Id { get; set; }

    public string FirsName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    public override string ToString()
    {
        return $"{FirsName.PadRight(20)} {LastName.PadRight(20)} {BirthDay.ToShortDateString()}";
    }
}
