import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Audio as AudioModel } from '../../../shared/models/audio.model';

@Component({
  selector: 'app-audio-small-player',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './audio-small-player.component.html',
})
export class AudioSmallPlayerComponent implements OnInit {
  @Input() audio: AudioModel;
  audiostream;
  isPlaying = false;
  isPaused = false;
  hasPlayed = false;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.audiostream = new Audio('/assets/' + this.audio.fragmentUrl);
    this.audiostream.load();
    this.audiostream.onpause = () => this.setPlayState(false, true);
    this.audiostream.onplaying = () => this.setPlayState(true, false);
  }

  playAudio() {
    this.audiostream.play();
    this.hasPlayed = true;
  }

  pauseAudio() {
    this.audiostream.pause();
  }

  setPlayState(playing: boolean, paused: boolean) {
    this.isPlaying = playing;
    this.isPaused = paused;
    this.cdr.detectChanges();
  }
}
