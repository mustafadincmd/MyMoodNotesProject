﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodNote.Entities
{
    [Table("Likes")]
    public class Liked
    {   [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Miras Myentities classından almadık çünkü sadece ıd istiyoruz

        public Note Note { get; set; }
        public NoteUser LikedUser { get; set; }

    }
}
