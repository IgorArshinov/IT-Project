import { Category } from './category.model';

export interface Video {
    id?: number;
    name?: string;
    videoUrl: string;
    categoryId?: number;
    categoryName?: string;
    level?: string;
}
