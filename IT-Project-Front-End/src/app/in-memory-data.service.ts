import { Injectable } from '@angular/core';
import {
  InMemoryDbService,
  ResponseOptions,
} from 'angular-in-memory-web-api';

@Injectable()
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const categories = [
      { id: 1, name: 'Wie ben jij?', imageUrl: 'wie-ben-jij.jpg' },
      { id: 2, name: 'Cijfers', imageUrl: 'cijfers.jpg' },
      { id: 3, name: 'Het weer', imageUrl: 'het-weer.png' },
      { id: 4, name: 'Tijd', imageUrl: 'tijd.jpg' },
      { id: 5, name: 'School', imageUrl: 'school.jpg' },
      { id: 6, name: 'Plaatsen / Ga je mee', imageUrl: 'plaatsen.jpg' },
      { id: 7, name: 'Afspraak', imageUrl: 'afspraak.jpg' },
      { id: 8, name: 'Vragen', imageUrl: 'vragen.jpg' },
      { id: 9, name: 'Eten en drinken', imageUrl: 'eten-en-drinken.jpg' },
      { id: 10, name: 'Kleding', imageUrl: 'kleding.jpg' },
      { id: 11, name: 'Winkel', imageUrl: 'winkel.jpg' },
      { id: 12, name: 'Wonen', imageUrl: 'wonen.jpg' },
      { id: 13, name: 'Gezondheid', imageUrl: 'gezondheid.jpg' },
      { id: 14, name: 'Verkeer', imageUrl: 'verkeer.jpg' },
      { id: 15, name: 'Werk', imageUrl: 'werk.jpg' },
      { id: 16, name: 'Vrije tijd', imageUrl: 'vrije-tijd.png' },
      { id: 17, name: 'Kinderen', imageUrl: 'kinderen.jpg' },
      { id: 18, name: 'Mening / gevoel', imageUrl: 'mening-gevoel.jpg' },
      { id: 19, name: 'Nieuw leven', imageUrl: 'nieuw-leven.jpg' },
      { id: 20, name: 'Documenten', imageUrl: 'documenten.jpg' },
      { id: 21, name: 'LiMiNo-filmpjes', imageUrl: 'limino-filmpjes.jpg' },
    ];

    const videos = [
      {
        id: 11,
        categoryId: 1,
        name: 'Wie ben jij?',
        videoUrl: 'https://www.youtube.com/embed/kvH9wlNrUTY',
        type: 'video',
      },
      { id: 12, categoryId: 1, name: 'Cijfers', videoUrl: 'https://www.youtube.com/embed/sHak0nIUsIQ', type: 'video' },
      { id: 13, categoryId: 1, name: 'Het weer', videoUrl: 'https://www.youtube.com/embed/1o_-LS34ntQ', type: 'video' },
      { id: 14, categoryId: 1, name: 'Tijd', videoUrl: 'https://www.youtube.com/embed/kvH9wlNrUTY', type: 'video' },
      { id: 15, categoryId: 1, name: 'School', videoUrl: 'https://www.youtube.com/embed/ZiOxgo5HbQM', type: 'video' },
      {
        id: 16,
        categoryId: 1,
        name: 'Plaatsen / Ga je mee',
        videoUrl: 'https://www.youtube.com/embed/w_nNIU88aVI',
        type: 'video',
      },
      { id: 17, categoryId: 1, name: 'Afspraak', videoUrl: 'https://www.youtube.com/embed/YXld4SDT2X4', type: 'video' },
      { id: 18, categoryId: 1, name: 'Vragen', videoUrl: 'https://www.youtube.com/embed/h1zaAu_7VR0', type: 'video' },
      {
        id: 19,
        categoryId: 1,
        name: 'Eten en drinken',
        videoUrl: 'https://www.youtube.com/embed/7btgD5cJxnY',
        type: 'video',
      },
    ];

    const exercises = [
      { id: 1, type: 'true or false', title: 'Oefening 1', categoryId: 1, questionUrl: 'hoe_laat_komt_de_bus.mp3', answers: [ { imageUrl: 'thumbsup.svg', isCorrect: false }, { imageUrl: 'thumbsdown.svg', isCorrect: true } ] },
      { id: 2, type: 'true or false', title: 'Oefening 2', categoryId: 1, questionUrl: 'kijk_naar_de_video_juist_of_out.wav', videoUrl: 'https://www.youtube.com/embed/h1zaAu_7VR0', answers: [ { imageUrl: 'thumbsup.svg', isCorrect: false }, { imageUrl: 'thumbsdown.svg', isCorrect: true } ] },
      { id: 3, type: 'collage', title: 'Oefening 3', categoryId: 1, questionUrl: 'ikZoekEenAppelVraag.mp3', videoUrl: 'https://www.youtube.com/embed/7btgD5cJxnY', answers: [ {imageUrl: 'appel.jpg', audioUrl: 'de_appel.mp3', isCorrect: true}, {imageUrl: 'banaan.jpg', audioUrl: 'de_banaan.mp3', isCorrect: false}, {imageUrl: 'sinaasappel.jpg', audioUrl: 'de_sinaasappel.mp3', isCorrect: false}, {imageUrl: 'aardbei.jpg', audioUrl: 'de_aardbei.mp3', isCorrect: false}, {imageUrl: 'druiven.jpg', audioUrl: 'de_druiven.mp3', isCorrect: false}, {imageUrl: 'kiwi.jpg', audioUrl: 'de_kiwi.mp3', isCorrect: false}, {imageUrl: 'komkommer.jpg', audioUrl: 'de_komkommer.mp3', isCorrect: false}, {imageUrl: 'tomaat.jpg', audioUrl: 'de_tomaat.mp3', isCorrect: false}, {imageUrl: 'wortel.jpg', audioUrl: 'de_wortel.mp3', isCorrect: false}, ] },
      { id: 4, type: 'multiple choice', categoryId: 1, title: 'Oefening 4', questionUrl: 'multiple_choice_question.mp3', videoUrl: 'https://www.youtube.com/embed/7btgD5cJxnY', answers: [ {imageUrl: 'taart.jpg', audioUrl: 'taart.mp3', isCorrect: false}, {imageUrl: 'koekjes.jpg', audioUrl: 'koekjes.mp3', isCorrect: true}, {imageUrl: 'muffin.jpg', audioUrl: 'muffins.mp3', isCorrect: false}, {imageUrl: 'brood.jpg', audioUrl: 'brood.mp3', isCorrect: false} ] },
      { id: 5, type: 'multiple choice', categoryId: 1, title: 'Oefening 5', questionUrl: 'multiple_choice_question.mp3', answers: [ { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false } ] },
      { id: 6, type: 'multiple choice', categoryId: 1, title: 'Oefening 6', questionUrl: 'wieBenJijAudio1.wav', answers: [ { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false } ] },
      { id: 7, type: 'multiple choice', categoryId: 1, title: 'Oefening 7', questionUrl: 'wieBenJijAudio1.wav', answers: [ { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false }, { imageUrl: 'eten-en-drinken.jpg', audioUrl: 'wieBenJijAudio1.wav', isCorrect: false } ] },
    ];

    const audios = [
      {
        id: 1,
        name: 'wieBenJijAudio1',
        fragmentUrl: 'wieBenJijAudio1.wav',
        imageUrl: 'wieBenJijAudio1.jpg',
        categoryId: 1,
      },
      {
        id: 2,
        name: 'wieBenJijAudio2',
        fragmentUrl: 'wieBenJijAudio2.wav',
        imageUrl: 'wieBenJijAudio2.jpg',
        categoryId: 1,
      },
      {
        id: 3,
        name: 'wieBenJijAudio3',
        fragmentUrl: 'wieBenJijAudio2.wav',
        imageUrl: 'wieBenJijAudio3.jpg',
        categoryId: 1,
      },
      { id: 4, name: 'één', fragmentUrl: 'één.mp3', imageUrl: 'één.jpg', categoryId: 2 },
      { id: 5, name: 'twee', fragmentUrl: 'twee.mp3', imageUrl: 'twee.jpg', categoryId: 2 },
      { id: 6, name: 'drie', fragmentUrl: 'drie.mp3', imageUrl: 'drie.jpg', categoryId: 2 },
      { id: 7, name: 'zonneschijn', fragmentUrl: 'zonneschijn.mp3', imageUrl: 'zonneschijn.jpg', categoryId: 3 },
      { id: 8, name: 'regen', fragmentUrl: 'regen.mp3', imageUrl: 'regen.jpg', categoryId: 3 },
      { id: 9, name: 'bewolkt', fragmentUrl: 'bewolkt.mp3', imageUrl: 'bewolkt.jpg', categoryId: 3 },
      { id: 10, name: 'twaalfUur', fragmentUrl: 'twaalfUur.mp3', imageUrl: 'twaalfUur.jpg', categoryId: 4 },
      {
        id: 11,
        name: 'kwartVoorTwee',
        fragmentUrl: 'kwartVoorTwee.mp3',
        imageUrl: 'kwartVoorTwee.jpg',
        categoryId: 4,
      },
      { id: 12, name: 'zesUur', fragmentUrl: 'zesUur.mp3', imageUrl: 'zesUur.jpg', categoryId: 4 },
      { id: 13, name: 'schoolAudio1', fragmentUrl: 'schoolAudio1.mp3', imageUrl: 'schoolAudio1.jpg', categoryId: 5 },
      { id: 14, name: 'schoolAudio2', fragmentUrl: 'schoolAudio2.mp3', imageUrl: 'schoolAudio2.jpg', categoryId: 5 },
      { id: 15, name: 'schoolAudio3', fragmentUrl: 'schoolAudio3.mp3', imageUrl: 'schoolAudio3.jpg', categoryId: 5 },
      { id: 16, name: 'amsterdam', fragmentUrl: 'amsterdam.mp3', imageUrl: 'amsterdam.jpg', categoryId: 6 },
      { id: 17, name: 'parijs', fragmentUrl: 'parijs.mp3', imageUrl: 'parijs.jpg', categoryId: 6 },
      { id: 18, name: 'brussel', fragmentUrl: 'brussel.mp3', imageUrl: 'brussel.jpg', categoryId: 6 },
      {
        id: 19,
        name: 'afspraakAudio1',
        fragmentUrl: 'afspraakAudio1.mp3',
        imageUrl: 'afspraakAudio1.jpg',
        categoryId: 7,
      },
      {
        id: 20,
        name: 'afspraakAudio2',
        fragmentUrl: 'afspraakAudio2.mp3',
        imageUrl: 'afspraakAudio2.jpg',
        categoryId: 7,
      },
      {
        id: 21,
        name: 'afspraakAudio3',
        fragmentUrl: 'afspraakAudio.mp3',
        imageUrl: 'afspraakAudio3.jpg',
        categoryId: 7,
      },
      { id: 22, name: 'vraagAudio1', fragmentUrl: 'vraagAudio1.mp3', imageUrl: 'vraagAudio1.jpg', categoryId: 8 },
      { id: 23, name: 'vraagAudio2', fragmentUrl: 'vraagAudio2.mp3', imageUrl: 'vraagAudio2.jpg', categoryId: 8 },
      { id: 24, name: 'vraagAudio3', fragmentUrl: 'vraagAudio3.mp3', imageUrl: 'vraagAudio3.jpg', categoryId: 8 },
      { id: 25, name: 'appelsien', fragmentUrl: 'de_sinaasappel.mp3', imageUrl: 'sinaasappel.jpg', categoryId: 9 },
      { id: 26, name: 'banaan', fragmentUrl: 'de_banaan.mp3', imageUrl: 'banaan.jpg', categoryId: 9 },
      { id: 27, name: 'appel', fragmentUrl: 'de_appel.mp3', imageUrl: 'appel.jpg', categoryId: 9 },
      { id: 28, name: 'broek', fragmentUrl: 'broek.mp3', imageUrl: 'broek.jpg', categoryId: 10 },
      { id: 29, name: 'trui', fragmentUrl: 'trui.mp3', imageUrl: 'trui.jpg', categoryId: 10 },
      { id: 30, name: 'schoenen', fragmentUrl: 'schoenen.mp3', imageUrl: 'schoenen.jpg', categoryId: 10 },
      { id: 31, name: 'winkelAudio1', fragmentUrl: 'winkelAudio1.mp3', imageUrl: 'winkelAudio1.jpg', categoryId: 11 },
      { id: 32, name: 'winkelAudio2', fragmentUrl: 'winkelAudio2.mp3', imageUrl: 'winkelAudio2.jpg', categoryId: 11 },
      { id: 33, name: 'winkelAudio3', fragmentUrl: 'winkelAudio3.mp3', imageUrl: 'winkelAudio3.jpg', categoryId: 1 },
      { id: 34, name: 'stoel', fragmentUrl: 'stoel.mp3', imageUrl: 'stoel.jpg', categoryId: 12 },
      { id: 35, name: 'tafel', fragmentUrl: 'tafel.mp3', imageUrl: 'tafel.jpg', categoryId: 12 },
      { id: 36, name: 'kast', fragmentUrl: 'kast.mp3', imageUrl: 'kast.jpg', categoryId: 12 },
      { id: 37, name: 'bloedneus', fragmentUrl: 'bloedneus.mp3', imageUrl: 'bloedneus.jpg', categoryId: 13 },
      { id: 38, name: 'naald', fragmentUrl: 'naald.mp3', imageUrl: 'naald.jpg', categoryId: 13 },
      { id: 39, name: 'medicijn', fragmentUrl: 'medicijn.mp3', imageUrl: 'medicijn.jpg', categoryId: 13 },
      {
        id: 40,
        name: 'verkeerslicht',
        fragmentUrl: 'verkeerslicht.mp3',
        imageUrl: 'verkeerslicht.jpg',
        categoryId: 14,
      },
      { id: 41, name: 'auto', fragmentUrl: 'auto.mp3', imageUrl: 'auto.jpg', categoryId: 14 },
      { id: 42, name: 'fiets', fragmentUrl: 'fiets.mp3', imageUrl: 'fiets.jpg', categoryId: 14 },
      { id: 43, name: 'bouwvakker', fragmentUrl: 'bouwvakker.mp3', imageUrl: 'bouwvakker.jpg', categoryId: 15 },
      { id: 44, name: 'leerkracht', fragmentUrl: 'leerkracht.mp3', imageUrl: 'leerkracht.jpg', categoryId: 15 },
      { id: 45, name: 'dokter', fragmentUrl: 'dokter.mp3', imageUrl: 'dokter.jpg', categoryId: 15 },
      { id: 46, name: 'fietsen', fragmentUrl: 'fietsen.mp3', imageUrl: 'fietsen.jpg', categoryId: 16 },
      { id: 47, name: 'voetballen', fragmentUrl: 'voetballen.mp3', imageUrl: 'voetballen.jpg', categoryId: 16 },
      { id: 48, name: 'zwemmen', fragmentUrl: 'zwemmen.mp3', imageUrl: 'zwemmen.jpg', categoryId: 16 },
      { id: 49, name: 'baby', fragmentUrl: 'baby.mp3', imageUrl: 'baby.jpg', categoryId: 17 },
      { id: 50, name: 'kleuter', fragmentUrl: 'kleuter.mp3', imageUrl: 'kleuter.jpg', categoryId: 17 },
      { id: 51, name: 'tiener', fragmentUrl: 'tiener.mp3', imageUrl: 'tiener.jpg', categoryId: 17 },
      { id: 52, name: 'blij', fragmentUrl: 'blij.mp3', imageUrl: 'blij.jpg', categoryId: 18 },
      { id: 53, name: 'verdrietig', fragmentUrl: 'verdrietig.mp3', imageUrl: 'verdrietig.jpg', categoryId: 18 },
      { id: 54, name: 'bang', fragmentUrl: 'bang.mp3', imageUrl: 'bang.jpg', categoryId: 18 },
      {
        id: 55,
        name: 'nieuwLevenAudio1',
        fragmentUrl: 'nieuwLievenAudio1.mp3',
        imageUrl: 'nieuwLevenAudio1.jpg',
        categoryId: 19,
      },
      {
        id: 56,
        name: 'nieuwLevenAudio2',
        fragmentUrl: 'nieuwLievenAudio2.mp3',
        imageUrl: 'nieuwLevenAudio2.jpg',
        categoryId: 19,
      },
      {
        id: 57,
        name: 'nieuwLevenAudio3',
        fragmentUrl: 'nieuwLievenAudio3.mp3',
        imageUrl: 'nieuwLevenAudio3.jpg',
        categoryId: 19,
      },
      {
        id: 58,
        name: 'identiteitskaart',
        fragmentUrl: 'identiteitskaart.mp3',
        imageUrl: 'identiteitskaart.jpg',
        categoryId: 20,
      },
      { id: 59, name: 'rijbewijs', fragmentUrl: 'rijbewijs.mp3', imageUrl: 'rijbewijs.jpg', categoryId: 20 },
      { id: 60, name: 'bankkaart', fragmentUrl: 'bankkaart.mp3', imageUrl: 'bankkaart.jpg', categoryId: 20 },
    ];

    const exerciseSeries = [
      { id: 1, name: "Oefenreeks 1", code: 1111, level: 'Moeilijk', exercises: [ 1, 3 ], },
      { id: 5, name: "Oefenreeks 5", code: 2222, level: '', exercises: [ 1, 3, 4, 5], },
      { id: 2, name: "Oefenreeks 2", code: 3333, level: 'Moeilijk', exercises: [ 1, 3, 4, 5, 6], },
      { id: 4, name: "Oefenreeks 4", code: 4444, level: 'Makkelijk', exercises: [ 1, 3, 4, 5], },
      { id: 6, name: "Oefenreeks 6", code: 5555, level: 'Gemiddeld', exercises: [ 1, 3, 4, 5], },
      { id: 3, name: "Oefenreeks 3", code: 6666, level: 'Makkelijk', exercises: [ 1,  4, 5], },
      { id: 7, name: "Oefenreeks 7", code: 7777, level: 'Gemiddeld', exercises: [ 1, 3, 4, 5], }
    ];

    return { categories, videos, audios, exercises, exerciseSeries };
  }

}
