using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyMoodNote.Entities;

namespace MyMoodNote.DataAccessLayer.EntityFramework
{
    public class MyInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //spesifik bir kullanıcı ekledik admin olarak
            NoteUser admin = new NoteUser()
            {
                Name = "Mustafa",
                Surname = "Dinç",
                Email = "mustafadiincmd@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserName = "mustafadinc",
                Password = "md141141m",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "mustafadinc"
            };

            NoteUser standartUser = new NoteUser()
            {

                Name = "Ali",
                Surname = "Dinç",
                Email = "mustafa965050@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                UserName = "alidinc",
                Password = "md141141m",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "mustafadinc"
            };

            context.NoteUsers.Add(admin);

            context.NoteUsers.Add(standartUser);

            for(int i=0; i<8; i++)
            {

                NoteUser user = new NoteUser()
                {

                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    UserName = $"user{i}",
                    Password = "123456",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{ i }"
                };
                context.NoteUsers.Add(user);
            }

            context.SaveChanges();
            //user listesi kullanmak için
            List<NoteUser> userlist = context.NoteUsers.ToList();

            //fake category ile veri üretiliyor
            for (int i= 0; i<10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "mustafadinc"

                };
                context.Categories.Add(cat);

                //fake note lar ekleniyor
                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    NoteUser owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Category = cat,
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1,9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.UserName,

                    };
                    cat.Notes.Add(note);

                    // fake commentsler ekleniyor
                    for(int j=0; j<FakeData.NumberData.GetNumber(3,5); j++)
                    {
                        NoteUser comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Note=note,
                            Owner= comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.UserName,

                        };
                        note.Comments.Add(comment);

                    }
                    // fake like ekleniyor
                    for ( int c= 0; c<note.LikeCount ;c++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[c]

                        };

                        note.Likes.Add(liked);
                    }

                }

            }

            context.SaveChanges();
        }

    }
}
