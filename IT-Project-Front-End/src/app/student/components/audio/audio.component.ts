import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Audio as AudioModel } from '../../../shared/models/audio.model';

@Component({
  selector: 'app-audio',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './audio.component.html',
})
export class AudioComponent implements OnInit {
  @Input() audio: AudioModel;
  audiostream;
  isPlaying = false;
  isPaused = false;
  isStopped = true;
  hasPlayed = false;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.audiostream = new Audio('/assets/' + this.audio.fragmentUrl);
    this.audiostream.load();
    this.audiostream.onended = this.stopAudio;
    this.audiostream.onpause = () => this.setPlayState(false, true, false);
    this.audiostream.onplaying = () => this.setPlayState(true, false, false);
  }

  playAudio() {
    this.audiostream.play();
    this.hasPlayed = true;
  }

  pauseAudio() {
    this.audiostream.pause();
  }

  stopAudio() {
    this.audiostream.pause();
    this.audiostream.currentTime = 0;
    this.hasPlayed = false;
    this.setPlayState(false, false, true);
  }

  setPlayState(playing: boolean, paused: boolean, stopped: boolean) {
    this.isPlaying = playing;
    this.isPaused = paused;
    this.isStopped = stopped;
    this.cdr.detectChanges();
  }
}
