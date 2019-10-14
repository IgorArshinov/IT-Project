import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { Video } from '../../../shared/models/video.model';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-video',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './video.component.html',
})
export class VideoComponent {
  @Input() video: Video;

  constructor(public sanitizer: DomSanitizer) {}

  query(...args) {
    return args.reduce((acc, curr, index) => `${acc}${index === 0 ? '?' : '&'}${curr}`, '');
  }
}
