import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { CourseService } from '../Services/Course.service';
import { Courses } from 'src/app/Model/Courses';
import { MatTable } from '@angular/material/table';
import { Router } from '@angular/router';


@Component({
  selector: 'app-newCourse',
  templateUrl: './newCourse.component.html',
  styleUrls: ['./newCourse.component.scss']
})

export class NewCourseComponent implements OnInit {
  @ViewChild(MatTable) listCourse? : MatTable<any>;
  displayedColumns: string[] = ['id', 'name', 'actions' ];
  dataSource!: Courses[];
  pageTitle = 'Adicionar Curso';
  course : any;
  selIndex! : number;

  constructor(
    private router: Router,
    private appcomponents : AppComponent,
    private courseService : CourseService) {

    this.appcomponents.pageTitle = "Cursos";
    this.course = new Courses();

  }

  ngOnInit() {
    this.courseService.List().subscribe((data: Courses[]) => {
      this.dataSource = data;
     })
  }

  onSubmit(){
    this.courseService.Save(this.course).subscribe(r => {this.course = r});
    location.reload();
  }

   myTabSelectedIndexChange(index: number) {
    this.selIndex = index;
  }

  onDelete(data : Courses){
    this.courseService.Delete(data.id).subscribe(r => {location.reload()});
  }

  onSelItem(data : Courses){
    this.course = data;
    this.selIndex = 0;
  }

}

