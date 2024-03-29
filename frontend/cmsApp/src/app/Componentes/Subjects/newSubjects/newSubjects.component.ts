import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { Courses } from 'src/app/Model/Courses';
import { Subjects } from 'src/app/Model/Subjects';
import { Teacher } from 'src/app/Model/Teacher';
import { CourseService } from '../../Courses/Services/Course.service';
import { TeacherService } from '../../Teacher/Services/Teacher.service';
import { SubjectsService } from '../Services/Subjects.service';

@Component({
  selector: 'app-newSubjects',
  templateUrl: './newSubjects.component.html',
  styleUrls: ['./newSubjects.component.scss']
})
export class NewSubjectsComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name','matricula','dtnascimento', 'actions' ];
  selIndex? : number;
  dataSource! : Subjects[];
  pageTitle = 'Adicionar Disciplinas';
  subjects : any;
  courses! : Courses[];
  teachers! : Teacher[];

  constructor(
      private subjectsService : SubjectsService,
      private courseService : CourseService,
      private teacherService : TeacherService,
      private appcomponents : AppComponent) {
       this.subjects = new Subjects();
       this.appcomponents.pageTitle = 'Disciplinas';
     }


  ngOnInit() {

    this.onGetList();

    this.courseService.List().subscribe(r => this.courses = r);

    this.teacherService.List().subscribe(r => this.teachers = r);
  }

  onGetList(){
    this.subjectsService.List().subscribe((data : Subjects[]) => {
      this.dataSource = data;
    });
  }

  myTabSelectedIndexChange(index: number) {
    this.selIndex = index;
  }

  onSubmit(){
    this.subjectsService.Save(this.subjects).subscribe(r => {
      this.subjects = r;
      this.onGetList();
    });
  }

  onSelItem(data : Subjects){
    this.subjects = data;
    this.selIndex = 0;
  }

  onDelete(data : Subjects){
    this.subjectsService.Delete(data.id).subscribe(r => {this.onGetList();})
  }

}
