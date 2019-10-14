import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { Category } from '../../../../shared/models/category.model';

@Component({
  selector: 'app-category',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './category.component.html',
})
export class CategoryComponent {
  @Input() category: Category;
}
