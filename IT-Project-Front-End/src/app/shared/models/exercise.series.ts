import { Exercise } from './exercise.model';

export interface ExerciseSeries {
  id: number;
  name?: string;
  code: number;
  exercises: number[];
}
