using MyMoodNote.DataAccessLayer.EntityFramework;
using MyMoodNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodNote.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();
        public List<Note> GetAllNote()
        {
            return repo_note.List();
        }

    }
}
