import { Exercise } from "./exercise.model";

export interface ExerciseSeries {
  shared: boolean;
  level: number;
  id: number;
  title: string;
  categoryId: number;
  code: number;
  searchTerms: string[];
  exercises: Exercise[];
}
