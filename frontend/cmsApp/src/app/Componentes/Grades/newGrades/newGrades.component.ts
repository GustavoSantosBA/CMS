import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { Grades } from 'src/app/Model/Grades';
import { Student } from 'src/app/Model/Stundent';
import { Subjects } from 'src/app/Model/Subjects';
import { StudentService } from '../../Student/Service/Student.service';
import { SubjectsService } from '../../Subjects/Services/Subjects.service';
import { GradesService } from '../Services/Grades.service';

@Component({
  selector: 'app-newGrades',
  templateUrl: './newGrades.component.html',
  styleUrls: ['./newGrades.component.scss']
})
export class NewGradesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'Aluno','Disciplina','Notas', 'actions' ];
  dataSource!: Grades[];
  pageTitle = 'Adicionar Notas';
  selIndex? : number;
  grades? : any;
  students! : Student[];
  subjects! : Subjects[];

  constructor(
    private appcomponents : AppComponent,
    private subjectsService : SubjectsService,
    private studentServices : StudentService,
    private gradesService : GradesService) {
      this.appcomponents.pageTitle = 'Notas';
      this.grades = new Grades();

     }

  ngOnInit() {

    // Get the list of subjects
    this.gradesService.List().subscribe((data : Grades[]) => {
      this.dataSource = data;
    });

    // Get the list of subjects
    this.subjectsService.List().subscribe(r => {this.subjects = r});

    // Get the list of students
    this.studentServices.List().subscribe(r => {this.students = r});
  }


  myTabSelectedIndexChange(index: number) {
    this.selIndex = index;
  }

  onSubmit(){
    this.gradesService.Save(this.grades).subscribe(r => {
      this.grades = r;
      location.reload();
    });
  }

  onSelItem(data : Grades){
    this.grades = data;
    this.selIndex = 0;
  }

  onDelete(data : Grades){
    this.gradesService.Delete(data.id).subscribe(r => {location.reload()})
  }
}
