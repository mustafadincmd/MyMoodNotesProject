using MyMoodNote.DataAccessLayer.EntityFramework;
using MyMoodNote.Entities;
using MyMoodNote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodNote.BusinessLayer
{
    public class MyMoodNoteUserManager
    {
        private Repository<NoteUser> repo_user = new Repository<NoteUser>();

        public BusinessLayerResult<NoteUser> RegisterUser (RegisterViewModel data)
        {

            //Kullanıcı Username kontrolü..
            //Kullanıcı eposta kontrolü.. 
            //kayıt işlemi 
            //aktivasyon epostası gönderimi 

            NoteUser user = repo_user.Find(x => x.UserName == data.Username|| x.Email == data.Email);

            BusinessLayerResult<NoteUser> layerResult = new BusinessLayerResult<NoteUser>();

            if (user != null)
            {
                if (user.UserName == data.Username)
                {
                    layerResult.Errors.Add("Kullanıcı adı kayıtlı.");

                }
                if (user.Email == data.Email)
                {
                    layerResult.Errors.Add("Eposta adresi kayıtlı.");

                }
            }
            else
            {
                int dbResult = repo_user.Insert(new NoteUser()
                {
                    UserName = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin=false
                });
                if (dbResult > 0)
                {
                    layerResult.Result = repo_user.Find(x=> x.Email == data.Email && x.UserName == data.Username);
                    
                    //layerResult.Act
                }
            }
            return layerResult;

        }
    }
}
