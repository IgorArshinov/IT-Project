import { Answer } from './answer.model';

export interface Exercise {
  id: number;
  name?: string;
  type: string;
  title: string;
  categoryId: number;
  questionUrl: string;
  videoUrl?: string;
  imageUrl?: string;
  answers?: Answer[];
  categoryName?: string;
  level?: string;
}
