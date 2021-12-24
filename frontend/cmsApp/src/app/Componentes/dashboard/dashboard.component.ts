import { Component, OnInit } from '@angular/core';
import { CourseService } from '../Courses/Services/Course.service';
import { StudentService } from '../Student/Service/Student.service';
import { SubjectsService } from '../Subjects/Services/Subjects.service';
import { TeacherService } from '../Teacher/Services/Teacher.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  countCourse   : number = 0;
  countTeacher  : number = 0;
  countSubjects : number = 0;
  countStudent  : number = 0;
  //
  pageTitle = "Indicadores";

  constructor(

    private teacherService  : TeacherService,
    private courseService   : CourseService,
    private studentServices : StudentService,
    private subjectsService : SubjectsService,

    ) { }

  ngOnInit() {

    this.teacherService.List().subscribe(r => this.countTeacher = r.length);
    this.courseService.List().subscribe(r => this.countCourse = r.length);
    this.studentServices.List().subscribe(r => this.countStudent = r.length);
    this.subjectsService.List().subscribe(r => this.countSubjects = r.length);

  }

}
