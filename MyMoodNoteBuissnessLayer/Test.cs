using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodNote.BusinessLayer
{
    public class Test
    {
        public Test()
        {

            MyMoodNote.DataAccessLayer.DatabaseContext db = new MyMoodNote.DataAccessLayer.DatabaseContext();

            /*Database Yok ise */
            /*  db.Database.CreateIfNotExists(); */

            db.Categories.ToList();


            //db.NoteUsers.ToList(); Kullanılablir 



        }
    }
}
