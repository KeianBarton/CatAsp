﻿using AspCat.Models;
using System.Collections.Generic;

namespace AspCat.ViewModels.CatViewModels
{
    public class CatsViewModel
    {
        public string Heading { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<Cat> Cats { get; set; }

    }
}
