using System;
using System.Collections.Generic;

namespace CodeChallenge.App.Core.Entities;

public partial class Director
{
    public Guid Uuid { get; set; }

    public string Name { get; set; }

    public DateTime Birthdate { get; set; }

    public virtual Movie Movie { get; set; }
}
