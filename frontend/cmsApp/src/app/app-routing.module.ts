import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewCourseComponent } from './Componentes/Courses/newCourse/newCourse.component';
import { DashboardComponent } from './Componentes/dashboard/dashboard.component';
import { NewGradesComponent } from './Componentes/Grades/newGrades/newGrades.component';
import { NewStudentComponent } from './Componentes/Student/newStudent/newStudent.component';
import { NewSubjectsComponent } from './Componentes/Subjects/newSubjects/newSubjects.component';
import { NewTeacherComponent } from './Componentes/Teacher/newTeacher/newTeacher.component';

const routes: Routes = [
  {path:'', component: DashboardComponent},
  {path:'Coursesnew', component: NewCourseComponent},
  {path:'Studentnew', component: NewStudentComponent},
  {path:'Teachernew', component: NewTeacherComponent},
  {path:'Gradesnew', component: NewGradesComponent},
  {path:'Subjectsnew', component: NewSubjectsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
