using System.Collections.Generic;

namespace ClockAndBranches.Models
{
    public class Matrioshka
    {
        public List<Matrioshka> Matrioshkas { get; set; } = new List<Matrioshka>();
    }
}
