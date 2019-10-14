import { Exercise } from './exercise.model';

export interface ExerciseSeriesModel {
  id: number;
  name?: string;
  code: number;
  level: string;
  exercises: any[];
}
