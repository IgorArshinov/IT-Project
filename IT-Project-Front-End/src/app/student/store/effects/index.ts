import { CategoryEffects } from './category.effects';
import { VideoEffects } from './video.effects';
import { AudioEffects } from './audio.effects';
import { ExerciseEffects } from './exercise.effects';
import { ExerciseSeriesEffects} from './exercise-series.effects';

export const effects: any[] = [CategoryEffects, VideoEffects, AudioEffects, ExerciseEffects, ExerciseSeriesEffects];

export * from './category.effects';
export * from './video.effects';
export * from './audio.effects';
export * from './exercise.effects';
export * from './exercise-series.effects';


