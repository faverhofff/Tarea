using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarea.Models
{
    public class Page
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        private int Matchs { get; set; }

        public void seWordMatchs(int value) { this.Matchs = value; }

        public int getWordMatchs() { return this.Matchs; }
    }
}