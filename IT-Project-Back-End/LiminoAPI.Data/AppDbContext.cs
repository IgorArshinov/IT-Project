using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LiminoAPI.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace LiminoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExerciseSeries> ExerciseSeries { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Empty constructor necessary
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                            new Category
                {Id = 1, Name = "Wie ben jij?", ImageUrl = "wie-ben-jij.jpg"},
            new Category {Id = 2, Name = "Cijfers", ImageUrl = "cijfers.jpg"},
            new Category {Id = 3, Name = "Het weer", ImageUrl = "het-weer.png"},
            new Category {Id = 4, Name = "Tijd", ImageUrl = "tijd.jpg"},
            new Category {Id = 5, Name = "School", ImageUrl = "school.jpg"},
            new Category
                {Id = 6, Name = "Plaatsen / Ga je mee", ImageUrl = "plaatsen.jpg"},
            new Category {Id = 7, Name = "Afspraak", ImageUrl = "afspraak.jpg"},
            new Category {Id = 8, Name = "Vragen", ImageUrl = "vragen.jpg"},
            new Category
                {Id = 9, Name = "Eten en drinken", ImageUrl = "eten-en-drinken.jpg"},
            new Category {Id = 10, Name = "Kleding", ImageUrl = "kleding.jpg"},
            new Category {Id = 11, Name = "Winkel", ImageUrl = "winkel.jpg"},
            new Category {Id = 12, Name = "Wonen", ImageUrl = "wonen.jpg"},
            new Category
                {Id = 13, Name = "Gezondheid", ImageUrl = "gezondheid.jpg"},
            new Category {Id = 14, Name = "Verkeer", ImageUrl = "verkeer.jpg"},
            new Category {Id = 15, Name = "Werk", ImageUrl = "werk.jpg"},
            new Category
                {Id = 16, Name = "Vrije tijd", ImageUrl = "vrije-tijd.png"},
            new Category {Id = 17, Name = "Kinderen", ImageUrl = "kinderen.jpg"},
            new Category
                {Id = 18, Name = "Mening / gevoel", ImageUrl = "mening-gevoel.jpg"},
            new Category
                {Id = 19, Name = "Nieuw leven", ImageUrl = "nieuw-leven.jpg"},
            new Category
                {Id = 20, Name = "Documenten", ImageUrl = "documenten.jpg"},
            new Category
                {Id = 21, Name = "LiMiNo-filmpjes", ImageUrl = "limino-filmpjes.jpg"});

            builder.Entity<Audio>().HasData(
                new Audio
                {
                    Id = 1, Name = "wieBenJijAudio1", FragmentUrl = "wieBenJijAudio1.wav",
                    ImageUrl = "wieBenJijAudio1.jpg", CategoryId = 1
                },
                new Audio
                {
                    Id = 2, Name = "wieBenJijAudio2", FragmentUrl = "wieBenJijAudio2.wav",
                    ImageUrl = "wieBenJijAudio2.jpg", CategoryId = 1
                },
                new Audio
                {
                    Id = 3, Name = "wieBenJijAudio3", FragmentUrl = "wieBenJijAudio2.wav",
                    ImageUrl = "wieBenJijAudio3.jpg", CategoryId = 1
                },
                new Audio {Id = 4, Name = "één", FragmentUrl = "één.mp3", ImageUrl = "één.jpg", CategoryId = 2},
                new Audio {Id = 5, Name = "twee", FragmentUrl = "twee.mp3", ImageUrl = "twee.jpg", CategoryId = 2},
                new Audio {Id = 6, Name = "drie", FragmentUrl = "drie.mp3", ImageUrl = "drie.jpg", CategoryId = 2},
                new Audio
                {
                    Id = 7, Name = "zonneschijn", FragmentUrl = "zonneschijn.mp3", ImageUrl = "zonneschijn.jpg",
                    CategoryId = 3
                },
                new Audio {Id = 8, Name = "regen", FragmentUrl = "regen.mp3", ImageUrl = "regen.jpg", CategoryId = 3},
                new Audio
                {
                    Id = 9, Name = "bewolkt", FragmentUrl = "bewolkt.mp3", ImageUrl = "bewolkt.jpg", CategoryId = 3
                },
                new Audio
                {
                    Id = 10, Name = "twaalfUur", FragmentUrl = "twaalfUur.mp3", ImageUrl = "twaalfUur.jpg",
                    CategoryId = 4
                },
                new Audio
                {
                    Id = 11, Name = "kwartVoorTwee", FragmentUrl = "kwartVoorTwee.mp3", ImageUrl = "kwartVoorTwee.jpg",
                    CategoryId = 4
                },
                new Audio
                {
                    Id = 12, Name = "zesUur", FragmentUrl = "zesUur.mp3", ImageUrl = "zesUur.jpg", CategoryId = 4
                },
                new Audio
                {
                    Id = 13, Name = "schoolAudio1", FragmentUrl = "schoolAudio1.mp3", ImageUrl = "schoolAudio1.jpg",
                    CategoryId = 5
                },
                new Audio
                {
                    Id = 14, Name = "schoolAudio2", FragmentUrl = "schoolAudio2.mp3", ImageUrl = "schoolAudio2.jpg",
                    CategoryId = 5
                },
                new Audio
                {
                    Id = 15, Name = "schoolAudio3", FragmentUrl = "schoolAudio3.mp3", ImageUrl = "schoolAudio3.jpg",
                    CategoryId = 5
                },
                new Audio
                {
                    Id = 16, Name = "amsterdam", FragmentUrl = "amsterdam.mp3", ImageUrl = "amsterdam.jpg",
                    CategoryId = 6
                },
                new Audio
                {
                    Id = 17, Name = "parijs", FragmentUrl = "parijs.mp3", ImageUrl = "parijs.jpg", CategoryId = 6
                },
                new Audio
                {
                    Id = 18, Name = "brussel", FragmentUrl = "brussel.mp3", ImageUrl = "brussel.jpg", CategoryId = 6
                },
                new Audio
                {
                    Id = 19, Name = "afspraakAudio1", FragmentUrl = "afspraakAudio1.mp3",
                    ImageUrl = "afspraakAudio1.jpg", CategoryId = 7
                },
                new Audio
                {
                    Id = 20, Name = "afspraakAudio2", FragmentUrl = "afspraakAudio2.mp3",
                    ImageUrl = "afspraakAudio2.jpg", CategoryId = 7
                },
                new Audio
                {
                    Id = 21, Name = "afspraakAudio3", FragmentUrl = "afspraakAudio.mp3",
                    ImageUrl = "afspraakAudio3.jpg", CategoryId = 7
                },
                new Audio
                {
                    Id = 22, Name = "vraagAudio1", FragmentUrl = "vraagAudio1.mp3", ImageUrl = "vraagAudio1.jpg",
                    CategoryId = 8
                },
                new Audio
                {
                    Id = 23, Name = "vraagAudio2", FragmentUrl = "vraagAudio2.mp3", ImageUrl = "vraagAudio2.jpg",
                    CategoryId = 8
                },
                new Audio
                {
                    Id = 24, Name = "vraagAudio3", FragmentUrl = "vraagAudio3.mp3", ImageUrl = "vraagAudio3.jpg",
                    CategoryId = 8
                },
                new Audio
                {
                    Id = 25, Name = "appelsien", FragmentUrl = "de_sinaasappel.mp3", ImageUrl = "sinaasappel.jpg",
                    CategoryId = 9
                },
                new Audio
                {
                    Id = 26, Name = "banaan", FragmentUrl = "de_banaan.mp3", ImageUrl = "banaan.jpg", CategoryId = 9
                },
                new Audio
                {
                    Id = 27, Name = "appel", FragmentUrl = "de_appel.mp3", ImageUrl = "appel.jpg", CategoryId = 9
                },
                new Audio {Id = 28, Name = "broek", FragmentUrl = "broek.mp3", ImageUrl = "broek.jpg", CategoryId = 10},
                new Audio {Id = 29, Name = "trui", FragmentUrl = "trui.mp3", ImageUrl = "trui.jpg", CategoryId = 10},
                new Audio
                {
                    Id = 30, Name = "schoenen", FragmentUrl = "schoenen.mp3", ImageUrl = "schoenen.jpg", CategoryId = 10
                },
                new Audio
                {
                    Id = 31, Name = "winkelAudio1", FragmentUrl = "winkelAudio1.mp3", ImageUrl = "winkelAudio1.jpg",
                    CategoryId = 11
                },
                new Audio
                {
                    Id = 32, Name = "winkelAudio2", FragmentUrl = "winkelAudio2.mp3", ImageUrl = "winkelAudio2.jpg",
                    CategoryId = 11
                },
                new Audio
                {
                    Id = 33, Name = "winkelAudio3", FragmentUrl = "winkelAudio3.mp3", ImageUrl = "winkelAudio3.jpg",
                    CategoryId = 11
                },
                new Audio {Id = 34, Name = "stoel", FragmentUrl = "stoel.mp3", ImageUrl = "stoel.jpg", CategoryId = 12},
                new Audio {Id = 35, Name = "tafel", FragmentUrl = "tafel.mp3", ImageUrl = "tafel.jpg", CategoryId = 12},
                new Audio {Id = 36, Name = "kast", FragmentUrl = "kast.mp3", ImageUrl = "kast.jpg", CategoryId = 12},
                new Audio
                {
                    Id = 37, Name = "bloedneus", FragmentUrl = "bloedneus.mp3", ImageUrl = "bloedneus.jpg",
                    CategoryId = 13
                },
                new Audio {Id = 38, Name = "naald", FragmentUrl = "naald.mp3", ImageUrl = "naald.jpg", CategoryId = 13},
                new Audio
                {
                    Id = 39, Name = "medicijn", FragmentUrl = "medicijn.mp3", ImageUrl = "medicijn.jpg", CategoryId = 13
                },
                new Audio
                {
                    Id = 40, Name = "verkeerslicht", FragmentUrl = "verkeerslicht.mp3", ImageUrl = "verkeerslicht.jpg",
                    CategoryId = 14
                },
                new Audio {Id = 41, Name = "auto", FragmentUrl = "auto.mp3", ImageUrl = "auto.jpg", CategoryId = 14},
                new Audio {Id = 42, Name = "fiets", FragmentUrl = "fiets.mp3", ImageUrl = "fiets.jpg", CategoryId = 14},
                new Audio
                {
                    Id = 43, Name = "bouwvakker", FragmentUrl = "bouwvakker.mp3", ImageUrl = "bouwvakker.jpg",
                    CategoryId = 15
                },
                new Audio
                {
                    Id = 44, Name = "leerkracht", FragmentUrl = "leerkracht.mp3", ImageUrl = "leerkracht.jpg",
                    CategoryId = 15
                },
                new Audio
                {
                    Id = 45, Name = "dokter", FragmentUrl = "dokter.mp3", ImageUrl = "dokter.jpg", CategoryId = 15
                },
                new Audio
                {
                    Id = 46, Name = "fietsen", FragmentUrl = "fietsen.mp3", ImageUrl = "fietsen.jpg", CategoryId = 16
                },
                new Audio
                {
                    Id = 47, Name = "voetballen", FragmentUrl = "voetballen.mp3", ImageUrl = "voetballen.jpg",
                    CategoryId = 16
                },
                new Audio
                {
                    Id = 48, Name = "zwemmen", FragmentUrl = "zwemmen.mp3", ImageUrl = "zwemmen.jpg", CategoryId = 16
                },
                new Audio {Id = 49, Name = "baby", FragmentUrl = "baby.mp3", ImageUrl = "baby.jpg", CategoryId = 17},
                new Audio
                {
                    Id = 50, Name = "kleuter", FragmentUrl = "kleuter.mp3", ImageUrl = "kleuter.jpg", CategoryId = 17
                },
                new Audio
                {
                    Id = 51, Name = "tiener", FragmentUrl = "tiener.mp3", ImageUrl = "tiener.jpg", CategoryId = 17
                },
                new Audio {Id = 52, Name = "blij", FragmentUrl = "blij.mp3", ImageUrl = "blij.jpg", CategoryId = 18},
                new Audio
                {
                    Id = 53, Name = "verdrietig", FragmentUrl = "verdrietig.mp3", ImageUrl = "verdrietig.jpg",
                    CategoryId = 18
                },
                new Audio {Id = 54, Name = "bang", FragmentUrl = "bang.mp3", ImageUrl = "bang.jpg", CategoryId = 18},
                new Audio
                {
                    Id = 55, Name = "nieuwLevenAudio1", FragmentUrl = "nieuwLievenAudio1.mp3",
                    ImageUrl = "nieuwLevenAudio1.jpg", CategoryId = 19
                },
                new Audio
                {
                    Id = 56, Name = "nieuwLevenAudio2", FragmentUrl = "nieuwLievenAudio2.mp3",
                    ImageUrl = "nieuwLevenAudio2.jpg", CategoryId = 19
                },
                new Audio
                {
                    Id = 57, Name = "nieuwLevenAudio3", FragmentUrl = "nieuwLievenAudio3.mp3",
                    ImageUrl = "nieuwLevenAudio3.jpg", CategoryId = 19
                },
                new Audio
                {
                    Id = 58, Name = "identiteitskaart", FragmentUrl = "identiteitskaart.mp3",
                    ImageUrl = "identiteitskaart.jpg", CategoryId = 20
                },
                new Audio
                {
                    Id = 59, Name = "rijbewijs", FragmentUrl = "rijbewijs.mp3", ImageUrl = "rijbewijs.jpg",
                    CategoryId = 20
                },
                new Audio
                {
                    Id = 60, Name = "bankkaart", FragmentUrl = "bankkaart.mp3", ImageUrl = "bankkaart.jpg",
                    CategoryId = 20
                }
            );
            builder.Entity<Video>().HasData(
                new Video
                {
                    Id = 11, CategoryId = 1, Name = "Wie ben jij?",
                    VideoUrl = "https://www.youtube.com/embed/kvH9wlNrUTY"
                },
                new Video
                {
                    Id = 12, CategoryId = 1, Name = "Cijfers", VideoUrl = "https://www.youtube.com/embed/sHak0nIUsIQ"
                },
                new Video
                {
                    Id = 13, CategoryId = 1, Name = "Het weer", VideoUrl = "https://www.youtube.com/embed/1o_-LS34ntQ"
                },
                new Video
                {
                    Id = 14, CategoryId = 1, Name = "Tijd", VideoUrl = "https://www.youtube.com/embed/kvH9wlNrUTY"
                },
                new Video
                {
                    Id = 15, CategoryId = 1, Name = "School", VideoUrl = "https://www.youtube.com/embed/ZiOxgo5HbQM"
                },
                new Video
                {
                    Id = 16, CategoryId = 1, Name = "Plaatsen / Ga je mee",
                    VideoUrl = "https://www.youtube.com/embed/w_nNIU88aVI"
                },
                new Video
                {
                    Id = 17, CategoryId = 1, Name = "Afspraak", VideoUrl = "https://www.youtube.com/embed/YXld4SDT2X4"
                },
                new Video
                {
                    Id = 18, CategoryId = 1, Name = "Vragen", VideoUrl = "https://www.youtube.com/embed/h1zaAu_7VR0"
                },
                new Video
                {
                    Id = 19, CategoryId = 1, Name = "Eten en drinken",
                    VideoUrl = "https://www.youtube.com/embed/7btgD5cJxnY"
                }
            );
            builder.Entity<Answer>().HasData(
                new Answer { Id = 1, ImageUrl = "Knop juist.png", IsCorrect = false, ExerciseId = 1},
                new Answer { Id = 2, ImageUrl = "Knop niet goed.png", IsCorrect = true, ExerciseId = 1},
                new Answer { Id = 3, ImageUrl = "Knop juist.png", IsCorrect = false, ExerciseId = 2},
                new Answer { Id = 4, ImageUrl = "Knop niet goed.png", IsCorrect = true, ExerciseId = 2},
                new Answer { Id = 5, ImageUrl = "appel.jpg", AudioUrl = "de_appel.mp3", IsCorrect = true, ExerciseId = 3},
                new Answer { Id = 6, ImageUrl = "banaan.jpg", AudioUrl = "de_banaan.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer
                { Id = 7, 
                    ImageUrl = "sinaasappel.jpg", AudioUrl = "de_sinaasappel.mp3", IsCorrect = false, ExerciseId = 3
                },
                new Answer { Id = 8, ImageUrl = "aardbei.jpg", AudioUrl = "de_aardbei.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 9, ImageUrl = "druiven.jpg", AudioUrl = "de_druiven.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 10, ImageUrl = "kiwi.jpg", AudioUrl = "de_kiwi.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 11, ImageUrl = "komkommer.jpg", AudioUrl = "de_komkommer.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 12, ImageUrl = "tomaat.jpg", AudioUrl = "de_tomaat.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 13, ImageUrl = "wortel.jpg", AudioUrl = "de_wortel.mp3", IsCorrect = false, ExerciseId = 3},
                new Answer { Id = 14, ImageUrl = "taart.jpg", AudioUrl = "taart.mp3", IsCorrect = false, ExerciseId = 4},
                new Answer { Id = 15, ImageUrl = "koekjes.jpg", AudioUrl = "koekjes.mp3", IsCorrect = true, ExerciseId = 4},
                new Answer { Id = 16, ImageUrl = "muffin.jpg", AudioUrl = "muffins.mp3", IsCorrect = false, ExerciseId = 4},
                new Answer { Id = 17, ImageUrl = "brood.jpg", AudioUrl = "brood.mp3", IsCorrect = false, ExerciseId = 4},
                new Answer
                { Id = 18, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 5
                },
                new Answer
                { Id = 19, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 5
                },
                new Answer
                { Id = 20, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 5
                },
                new Answer
                { Id = 21, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 5
                },
                new Answer
                { Id = 22, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 6
                },
                new Answer
                { Id = 23, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 6
                },
                new Answer
                { Id = 24, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 6
                },
                new Answer
                { Id = 25, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = false, ExerciseId = 7
                },
                new Answer
                { Id = 26, 
                    ImageUrl = "eten-en-drinken.jpg", AudioUrl = "wieBenJijAudio1.wav", IsCorrect = true, ExerciseId = 7
                }
            );
            builder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1, Type = "true or false", Title = "Oefening 1", CategoryId = 1,
                    QuestionUrl = "hoe_laat_komt_de_bus.mp3", Level = Levels.Makkelijk
                },
                new Exercise
                {
                    Id = 2, Type = "true or false", Title = "Oefening 2", CategoryId = 1,
                    QuestionUrl = "kijk_naar_de_video_juist_of_out.wav",
                    VideoUrl = "https://www.youtube.com/embed/h1zaAu_7VR0",
                    Level = Levels.Gemiddeld
                },
                new Exercise
                {
                    Id = 3, Type = "collage", Title = "Oefening 3", CategoryId = 1,
                    QuestionUrl = "ikZoekEenAppelVraag.mp3", VideoUrl = "https://www.youtube.com/embed/7btgD5cJxnY",
                    Level = Levels.Moeilijk
                },
                new Exercise
                {
                    Id = 4, Type = "multiple choice", CategoryId = 1, Title = "Oefening 4",
                    QuestionUrl = "multiple_choice_question.mp3",
                    VideoUrl = "https://www.youtube.com/embed/7btgD5cJxnY",
                    Level = Levels.Moeilijk
                },
                new Exercise
                {
                    Id = 5, Type = "multiple choice", CategoryId = 1, Title = "Oefening 5",
                    QuestionUrl = "multiple_choice_question.mp3",
                    Level = Levels.Moeilijk
                },
                new Exercise
                {
                    Id = 6, Type = "multiple choice", CategoryId = 1, Title = "Oefening 6",
                    QuestionUrl = "wieBenJijAudio1.wav",
                    Level = Levels.Gemiddeld
                },
                new Exercise
                {
                    Id = 7, Type = "multiple choice", CategoryId = 1, Title = "Oefening 7",
                    QuestionUrl = "wieBenJijAudio1.wav", Level = Levels.Makkelijk
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1, Username = "admin@limino.be",
                    PasswordHash =
                        StringToByteArray(
                            "7B85DAFC196755690BED2BA4059F860A69BA60435E33EF0A6733380D8D5ADC5686D3C425A95303B641CEBA454E28FC2A79A5E7FB62EC68F3A379B4DCBC65E574"),
                    PasswordSalt = StringToByteArray(
                        "917C24BD5D20F8B34B1F0CDCEAE31F69AD74726CCCE1C95884FEF39D665F0F2E0A98EF6B04281EF0A8AAB832A54CD20EE50B0D1F4F2BC80828AB0E5EEA534273822422771694ABD6462C6CB635BD254C725B65D30BD2A142D7B174F8C7354B90A7FF2823560D91F656AE7AC12F604F4391AEAEF44265A71A9923CFF1DF97212E"),
                    Role = Role.Admin
                }
                ,
                new User
                {
                    Id = 2, Username = "teacher@limino.be",
                    PasswordHash =
                        StringToByteArray(
                            "7B85DAFC196755690BED2BA4059F860A69BA60435E33EF0A6733380D8D5ADC5686D3C425A95303B641CEBA454E28FC2A79A5E7FB62EC68F3A379B4DCBC65E574"),
                    PasswordSalt = StringToByteArray(
                        "917C24BD5D20F8B34B1F0CDCEAE31F69AD74726CCCE1C95884FEF39D665F0F2E0A98EF6B04281EF0A8AAB832A54CD20EE50B0D1F4F2BC80828AB0E5EEA534273822422771694ABD6462C6CB635BD254C725B65D30BD2A142D7B174F8C7354B90A7FF2823560D91F656AE7AC12F604F4391AEAEF44265A71A9923CFF1DF97212E"),
                    Role = Role.User
                }
            );

            builder.Entity<ExerciseSeriesExercises>().HasKey(ese => new {ese.ExerciseId, ese.ExerciseSeriesId});

            builder.HasSequence<int>("CodeNumbers", schema: "liminoDb" )
                .StartsAt(1000)
                .IncrementsBy(1) ;
            
            builder.Entity<ExerciseSeries>()
                .Property(es => es.Code)
                .HasDefaultValueSql("NEXT VALUE FOR liminoDb.CodeNumbers");

        }

        private static byte[] StringToByteArray(string hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}