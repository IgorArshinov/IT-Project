import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './root-components';

const routes: Routes = [
  {
    path: 'student',
    loadChildren: './student/student.module#StudentModule',
  },
  {
    path: 'teacher',
    loadChildren: './teacher/teacher.module#TeacherModule',
  },
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
