using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csApi.Dtos
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
