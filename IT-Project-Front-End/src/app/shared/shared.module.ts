import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ClickOutsideDirective } from './directives/click-outside.directive';

import { components } from './components';
import { pipes } from './pipes';
import { NavNextComponent } from './components/nav-next/nav-next.component';

const directives = [ClickOutsideDirective];

@NgModule({
  declarations: [...components, ...directives, ...pipes, NavNextComponent],
  imports: [CommonModule, RouterModule],
  exports: [components, directives, pipes, NavNextComponent],
})
export class SharedModule {}
