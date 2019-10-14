import { Category } from '../../../shared/models/category.model';
import { Component, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-categories',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './categories.component.html',
})
export class CategoriesComponent {
  @Input() categories: Category[];
}
