using Microsoft.EntityFrameworkCore.Migrations;

namespace LiminoAPI.Migrations
{
    public partial class ChangeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Exercises",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { null, "Knop juist.png" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { null, true, "Knop niet goed.png" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { null, false, 2L, "Knop juist.png" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { null, true, "Knop niet goed.png" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { "de_appel.mp3", true, 3L, "appel.jpg" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { "de_banaan.mp3", false, 3L, "banaan.jpg" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { "de_sinaasappel.mp3", "sinaasappel.jpg" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { "de_aardbei.mp3", "aardbei.jpg" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { "de_druiven.mp3", false, "druiven.jpg" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[,]
                {
                    { 10L, "de_kiwi.mp3", false, 3L, "kiwi.jpg" },
                    { 11L, "de_komkommer.mp3", false, 3L, "komkommer.jpg" },
                    { 12L, "de_tomaat.mp3", false, 3L, "tomaat.jpg" },
                    { 13L, "de_wortel.mp3", false, 3L, "wortel.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "video", "wie-ben-jij.jpg", "Wie ben jij?" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "video", "cijfers.jpg", "Cijfers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "video", "het-weer.png", "Het weer" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 38L, "audio", "kinderen.jpg", "Kinderen" },
                    { 39L, "audio", "mening-gevoel.jpg", "Mening / gevoel" },
                    { 40L, "audio", "nieuw-leven.jpg", "Nieuw leven" },
                    { 41L, "audio", "wie-ben-jij.jpg", "Wie ben jij?" },
                    { 42L, "conversation", "cijfers.jpg", "Cijfers" },
                    { 43L, "conversation", "het-weer.png", "Het weer" },
                    { 44L, "conversation", "tijd.jpg", "Tijd" },
                    { 45L, "conversation", "school.jpg", "School" },
                    { 46L, "conversation", "plaatsen.jpg", "Plaatsen / Ga je mee" },
                    { 47L, "conversation", "afspraak.jpg", "Afspraak" },
                    { 48L, "exercise", "vragen.jpg", "Vragen" },
                    { 49L, "exercise", "eten-en-drinken.jpg", "Eten en drinken" },
                    { 50L, "exercise", "kleding.jpg", "Kleding" },
                    { 51L, "exercise", "winkel.jpg", "Winkel" },
                    { 59L, "exercise", "nieuw-leven.jpg", "Nieuw leven" },
                    { 53L, "exercise", "gezondheid.jpg", "Gezondheid" },
                    { 54L, "exercise", "verkeer.jpg", "Verkeer" },
                    { 55L, "exercise", "werk.jpg", "Werk" },
                    { 56L, "exercise", "vrije-tijd.png", "Vrije tijd" },
                    { 57L, "exercise", "kinderen.jpg", "Kinderen" },
                    { 58L, "exercise", "mening-gevoel.jpg", "Mening / gevoel" },
                    { 37L, "audio", "vrije-tijd.png", "Vrije tijd" },
                    { 60L, "exercise", "wie-ben-jij.jpg", "Wie ben jij?" },
                    { 61L, "exercise", "cijfers.jpg", "Cijfers" },
                    { 62L, "exercise", "het-weer.png", "Het weer" },
                    { 63L, "exercise", "tijd.jpg", "Tijd" },
                    { 64L, "exercise", "school.jpg", "School" },
                    { 65L, "exercise", "plaatsen.jpg", "Plaatsen / Ga je mee" },
                    { 66L, "exercise", "afspraak.jpg", "Afspraak" },
                    { 52L, "exercise", "wonen.jpg", "Wonen" },
                    { 36L, "audio", "werk.jpg", "Werk" },
                    { 35L, "audio", "verkeer.jpg", "Verkeer" },
                    { 34L, "audio", "gezondheid.jpg", "Gezondheid" },
                    { 4L, "video", "tijd.jpg", "Tijd" },
                    { 5L, "video", "school.jpg", "School" },
                    { 6L, "video", "plaatsen.jpg", "Plaatsen / Ga je mee" },
                    { 7L, "video", "afspraak.jpg", "Afspraak" },
                    { 8L, "video", "vragen.jpg", "Vragen" },
                    { 9L, "video", "eten-en-drinken.jpg", "Eten en drinken" },
                    { 10L, "video", "kleding.jpg", "Kleding" },
                    { 12L, "video", "wonen.jpg", "Wonen" },
                    { 13L, "video", "gezondheid.jpg", "Gezondheid" },
                    { 14L, "video", "verkeer.jpg", "Verkeer" },
                    { 15L, "video", "werk.jpg", "Werk" },
                    { 16L, "video", "vrije-tijd.png", "Vrije tijd" },
                    { 17L, "video", "kinderen.jpg", "Kinderen" },
                    { 18L, "video", "mening-gevoel.jpg", "Mening / gevoel" },
                    { 11L, "video", "winkel.jpg", "Winkel" },
                    { 20L, "video", "documenten.jpg", "Documenten" },
                    { 21L, "video", "limino-filmpjes.jpg", "LiMiNo-filmpjes" },
                    { 22L, "audio", "wie-ben-jij.jpg", "Wie ben jij?" },
                    { 23L, "audio", "cijfers.jpg", "Cijfers" },
                    { 24L, "audio", "het-weer.png", "Het weer" },
                    { 25L, "audio", "tijd.jpg", "Tijd" },
                    { 26L, "audio", "school.jpg", "School" },
                    { 19L, "video", "nieuw-leven.jpg", "Nieuw leven" },
                    { 27L, "audio", "plaatsen.jpg", "Plaatsen / Ga je mee" },
                    { 28L, "audio", "afspraak.jpg", "Afspraak" },
                    { 29L, "audio", "vragen.jpg", "Vragen" },
                    { 30L, "audio", "eten-en-drinken.jpg", "Eten en drinken" },
                    { 31L, "audio", "kleding.jpg", "Kleding" },
                    { 32L, "audio", "winkel.jpg", "Winkel" },
                    { 33L, "audio", "wonen.jpg", "Wonen" }
                });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Name", "QuestionUrl", "Title", "Type", "VideoUrl" },
                values: new object[] { null, "hoe_laat_komt_de_bus.mp3", "Oefening 1", "true or false", null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "Name", "QuestionUrl", "Title", "Type", "VideoUrl" },
                values: new object[] { 1L, null, "kijk_naar_de_video_juist_of_out.wav", "Oefening 2", "true or false", "https://www.youtube.com/embed/h1zaAu_7VR0" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "Name", "QuestionUrl", "Title", "Type", "VideoUrl" },
                values: new object[] { 1L, null, "ikZoekEenAppelVraag.mp3", "Oefening 3", "collage", "https://www.youtube.com/embed/7btgD5cJxnY" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Name", "QuestionUrl", "Title", "Type", "VideoUrl" },
                values: new object[,]
                {
                    { 4L, 1L, null, "multiple_choice_question.mp3", "Oefening 4", "multiple choice", "https://www.youtube.com/embed/7btgD5cJxnY" },
                    { 5L, 1L, null, "multiple_choice_question.mp3", "Oefening 5", "multiple choice", null },
                    { 6L, 1L, null, "wieBenJijAudio1.wav", "Oefening 6", "multiple choice", null },
                    { 7L, 1L, null, "wieBenJijAudio1.wav", "Oefening 7", "multiple choice", null }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 11L, 1L, "Wie ben jij?", "https://www.youtube.com/embed/kvH9wlNrUTY" },
                    { 12L, 1L, "Cijfers", "https://www.youtube.com/embed/sHak0nIUsIQ" },
                    { 13L, 1L, "Het weer", "https://www.youtube.com/embed/1o_-LS34ntQ" },
                    { 14L, 1L, "Tijd", "https://www.youtube.com/embed/kvH9wlNrUTY" },
                    { 15L, 1L, "School", "https://www.youtube.com/embed/ZiOxgo5HbQM" },
                    { 16L, 1L, "Plaatsen / Ga je mee", "https://www.youtube.com/embed/w_nNIU88aVI" },
                    { 17L, 1L, "Afspraak", "https://www.youtube.com/embed/YXld4SDT2X4" },
                    { 18L, 1L, "Vragen", "https://www.youtube.com/embed/h1zaAu_7VR0" },
                    { 19L, 1L, "Eten en drinken", "https://www.youtube.com/embed/7btgD5cJxnY" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[,]
                {
                    { 26L, "wieBenJijAudio1.wav", true, 7L, "eten-en-drinken.jpg" },
                    { 24L, "wieBenJijAudio1.wav", false, 6L, "eten-en-drinken.jpg" },
                    { 23L, "wieBenJijAudio1.wav", false, 6L, "eten-en-drinken.jpg" },
                    { 22L, "wieBenJijAudio1.wav", false, 6L, "eten-en-drinken.jpg" },
                    { 21L, "wieBenJijAudio1.wav", false, 5L, "eten-en-drinken.jpg" },
                    { 20L, "wieBenJijAudio1.wav", false, 5L, "eten-en-drinken.jpg" },
                    { 19L, "wieBenJijAudio1.wav", false, 5L, "eten-en-drinken.jpg" },
                    { 18L, "wieBenJijAudio1.wav", false, 5L, "eten-en-drinken.jpg" },
                    { 17L, "brood.mp3", false, 4L, "brood.jpg" },
                    { 16L, "muffins.mp3", false, 4L, "muffin.jpg" },
                    { 15L, "koekjes.mp3", true, 4L, "koekjes.jpg" },
                    { 14L, "taart.mp3", false, 4L, "taart.jpg" },
                    { 25L, "wieBenJijAudio1.wav", false, 7L, "eten-en-drinken.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 22L, "wieBenJijAudio1.wav", "wieBenJijAudio1.jpg", "wieBenJijAudio1" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 22L, "wieBenJijAudio2.wav", "wieBenJijAudio2.jpg", "wieBenJijAudio2" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 22L, "wieBenJijAudio2.wav", "wieBenJijAudio3.jpg", "wieBenJijAudio3" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 23L, "één.mp3", "één.jpg", "één" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 23L, "twee.mp3", "twee.jpg", "twee" });

            migrationBuilder.InsertData(
                table: "Audios",
                columns: new[] { "Id", "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 15L, 26L, "schoolAudio3.mp3", "schoolAudio3.jpg", "schoolAudio3" },
                    { 46L, 37L, "fietsen.mp3", "fietsen.jpg", "fietsen" },
                    { 47L, 37L, "voetballen.mp3", "voetballen.jpg", "voetballen" },
                    { 48L, 37L, "zwemmen.mp3", "zwemmen.jpg", "zwemmen" },
                    { 49L, 38L, "baby.mp3", "baby.jpg", "baby" },
                    { 50L, 38L, "kleuter.mp3", "kleuter.jpg", "kleuter" },
                    { 51L, 38L, "tiener.mp3", "tiener.jpg", "tiener" },
                    { 52L, 39L, "blij.mp3", "blij.jpg", "blij" },
                    { 53L, 39L, "verdrietig.mp3", "verdrietig.jpg", "verdrietig" },
                    { 54L, 39L, "bang.mp3", "bang.jpg", "bang" },
                    { 55L, 40L, "nieuwLievenAudio1.mp3", "nieuwLevenAudio1.jpg", "nieuwLevenAudio1" },
                    { 56L, 40L, "nieuwLievenAudio2.mp3", "nieuwLevenAudio2.jpg", "nieuwLevenAudio2" },
                    { 58L, 41L, "identiteitskaart.mp3", "identiteitskaart.jpg", "identiteitskaart" },
                    { 45L, 36L, "dokter.mp3", "dokter.jpg", "dokter" },
                    { 59L, 41L, "rijbewijs.mp3", "rijbewijs.jpg", "rijbewijs" },
                    { 60L, 41L, "bankkaart.mp3", "bankkaart.jpg", "bankkaart" },
                    { 12L, 25L, "zesUur.mp3", "zesUur.jpg", "zesUur" },
                    { 11L, 25L, "kwartVoorTwee.mp3", "kwartVoorTwee.jpg", "kwartVoorTwee" },
                    { 10L, 25L, "twaalfUur.mp3", "twaalfUur.jpg", "twaalfUur" },
                    { 9L, 24L, "bewolkt.mp3", "bewolkt.jpg", "bewolkt" },
                    { 8L, 24L, "regen.mp3", "regen.jpg", "regen" },
                    { 7L, 24L, "zonneschijn.mp3", "zonneschijn.jpg", "zonneschijn" },
                    { 6L, 23L, "drie.mp3", "drie.jpg", "drie" },
                    { 57L, 40L, "nieuwLievenAudio3.mp3", "nieuwLevenAudio3.jpg", "nieuwLevenAudio3" },
                    { 14L, 26L, "schoolAudio2.mp3", "schoolAudio2.jpg", "schoolAudio2" },
                    { 44L, 36L, "leerkracht.mp3", "leerkracht.jpg", "leerkracht" },
                    { 42L, 35L, "fiets.mp3", "fiets.jpg", "fiets" },
                    { 16L, 27L, "amsterdam.mp3", "amsterdam.jpg", "amsterdam" },
                    { 17L, 27L, "parijs.mp3", "parijs.jpg", "parijs" },
                    { 18L, 27L, "brussel.mp3", "brussel.jpg", "brussel" },
                    { 19L, 28L, "afspraakAudio1.mp3", "afspraakAudio1.jpg", "afspraakAudio1" },
                    { 20L, 28L, "afspraakAudio2.mp3", "afspraakAudio2.jpg", "afspraakAudio2" },
                    { 21L, 28L, "afspraakAudio.mp3", "afspraakAudio3.jpg", "afspraakAudio3" },
                    { 22L, 29L, "vraagAudio1.mp3", "vraagAudio1.jpg", "vraagAudio1" },
                    { 23L, 29L, "vraagAudio2.mp3", "vraagAudio2.jpg", "vraagAudio2" },
                    { 24L, 29L, "vraagAudio3.mp3", "vraagAudio3.jpg", "vraagAudio3" },
                    { 25L, 30L, "de_sinaasappel.mp3", "sinaasappel.jpg", "appelsien" },
                    { 26L, 30L, "de_banaan.mp3", "banaan.jpg", "banaan" },
                    { 27L, 30L, "de_appel.mp3", "appel.jpg", "appel" },
                    { 43L, 36L, "bouwvakker.mp3", "bouwvakker.jpg", "bouwvakker" },
                    { 28L, 31L, "broek.mp3", "broek.jpg", "broek" },
                    { 30L, 31L, "schoenen.mp3", "schoenen.jpg", "schoenen" },
                    { 31L, 32L, "winkelAudio1.mp3", "winkelAudio1.jpg", "winkelAudio1" },
                    { 32L, 32L, "winkelAudio2.mp3", "winkelAudio2.jpg", "winkelAudio2" },
                    { 33L, 32L, "winkelAudio3.mp3", "winkelAudio3.jpg", "winkelAudio3" },
                    { 34L, 33L, "stoel.mp3", "stoel.jpg", "stoel" },
                    { 35L, 33L, "tafel.mp3", "tafel.jpg", "tafel" },
                    { 36L, 33L, "kast.mp3", "kast.jpg", "kast" },
                    { 13L, 26L, "schoolAudio1.mp3", "schoolAudio1.jpg", "schoolAudio1" },
                    { 38L, 34L, "naald.mp3", "naald.jpg", "naald" },
                    { 39L, 34L, "medicijn.mp3", "medicijn.jpg", "medicijn" },
                    { 40L, 35L, "verkeerslicht.mp3", "verkeerslicht.jpg", "verkeerslicht" },
                    { 41L, 35L, "auto.mp3", "auto.jpg", "auto" },
                    { 29L, 31L, "trui.mp3", "trui.jpg", "trui" },
                    { 37L, 34L, "bloedneus.mp3", "bloedneus.jpg", "bloedneus" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { "AudioUrl1", "ImgUrl1" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { "AudioUrl2", false, "ImgUrl2" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { "AudioUrl3", true, 1L, "ImgUrl3" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { "AudioUrl1", false, "ImgUrl1" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { "AudioUrl2", false, 2L, "ImgUrl2" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "AudioUrl", "Correct", "ExerciseId", "ImageUrl" },
                values: new object[] { "AudioUrl3", true, 2L, "ImgUrl3" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { "AudioUrl1", "ImgUrl1" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "AudioUrl", "ImageUrl" },
                values: new object[] { "AudioUrl2", "ImgUrl2" });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "AudioUrl", "Correct", "ImageUrl" },
                values: new object[] { "AudioUrl3", true, "ImgUrl3" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 1L, "audioUrl1", "imageUrl4", "Dit is een banaan" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 1L, "audioUrl3", "imageUrl7", "Dit is een appel" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 2L, "audioUrl2", "imageUrl5", "welke bus moet ik nemen?" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 2L, "audioUrl2", "imageUrl8", "hoe neem ik een taxi?" });

            migrationBuilder.UpdateData(
                table: "Audios",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CategoryId", "FragmentUrl", "ImageUrl", "Name" },
                values: new object[] { 3L, "audioUrl3", "imageUrl5", "Mag ik een glas water?" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "Video", "imageUrl1", "food" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "Audio", "imageUrl2", "traffic" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryType", "ImageUrl", "Name" },
                values: new object[] { "Audio", "imageUrl3", "drinks" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Name", "QuestionUrl", "Type", "VideoUrl" },
                values: new object[] { "First Question", "questionUrl", "Collage", "videoUrl" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "Name", "QuestionUrl", "Type", "VideoUrl" },
                values: new object[] { 2L, "Second Question", "questionUrl2", "True Or False", "videoUrl2" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "Name", "QuestionUrl", "Type", "VideoUrl" },
                values: new object[] { 3L, "Second Question", "questionUrl3", "Multiple Choice", "videoUrl3" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1L, 1L, "Video van een banaan", "VideoUrl1" },
                    { 4L, 1L, "Video van een appel", "VideoUrl2" },
                    { 2L, 2L, "Video van een bus", "VideoUrl2" },
                    { 3L, 3L, "Video van een glas water", "VideoUrl3" }
                });
        }
    }
}
