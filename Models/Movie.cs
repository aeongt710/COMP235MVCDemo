using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP235MVCDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }

        //Set whether the Object is editable or not.
        public bool IsEditable { get; set; }
       
        //Default constructor
        public Movie() { }

        //Constructor without Description Field
        public Movie(int id, string title, string director)
        {
            Id = id;
            Title = title;
            Director = director;
        }

        //Constructor with Description Field
        public Movie(int id, string title, string director, string description)
        {
            Id = id;
            Title = title;
            Director = director;
            Description = description;
        }

    }
}