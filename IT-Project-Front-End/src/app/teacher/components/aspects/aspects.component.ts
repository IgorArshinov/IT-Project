import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from '../../../shared/models/category.model';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-aspects-exercise',
  templateUrl: './aspects.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AspectsComponent implements OnInit{
  @Input() categories: Category[];
  levels = ['Makkelijk', 'Gemiddeld', 'Moeilijk'];
  form: FormGroup;
  @Output() aspects = new EventEmitter();
  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(),
      level: new FormControl(),
      categories: new FormControl(),
    });
  }

  click() {
    this.aspects.emit({
      name: this.form.get('name').value,
      level: this.form.get('level').value,
      categoryId: this.form.get('categories').value
    });
  }
}
