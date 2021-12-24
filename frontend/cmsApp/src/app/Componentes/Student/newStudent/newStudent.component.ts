import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { Student } from 'src/app/Model/Stundent';
import { StudentService } from '../Service/Student.service';




@Component({
  selector: 'app-newStudent',
  templateUrl: './newStudent.component.html',
  styleUrls: ['./newStudent.component.scss'],
  providers: [

  ]
})
export class NewStudentComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name','matricula','dtnascimento', 'actions' ];
  dataSource!: Student[];
  pageTitle = 'Adicionar Aluno';
  selIndex? : number;
  student? : any;


  constructor (
    private appcomponents : AppComponent,
    private studentServices : StudentService
    ) {
    this.appcomponents.pageTitle = 'Alunos';
    this.student = new Student();
  }

  ngOnInit() {
    this.studentServices.List().subscribe((data : Student[]) => {
      this.dataSource = data;
    });
  }

  myTabSelectedIndexChange(index: number) {
    this.selIndex = index;
  }

  onSubmit(){
    this.studentServices.Save(this.student).subscribe(r => {
      this.student = r;
      location.reload();
    });
  }

  onSelItem(data : Student){
    this.student = data;
    this.selIndex = 0;
  }

  onDelete(data : Student){
    this.studentServices.Delete(data.id).subscribe(r => {location.reload()})
  }

}
