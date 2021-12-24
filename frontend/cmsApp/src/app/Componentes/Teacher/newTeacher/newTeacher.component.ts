import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { Teacher } from 'src/app/Model/Teacher';
import { TeacherService } from '../Services/Teacher.service';

@Component({
  selector: 'app-newTeacher',
  templateUrl: './newTeacher.component.html',
  styleUrls: ['./newTeacher.component.scss']
})
export class NewTeacherComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name','dtnascimento', 'salary','actions' ];
  dataSource!: Teacher[];
  teacher? : any;
  selIndex?: number;
  pageTitle = 'Adicionar Professor';
  constructor(
    private appcomponents : AppComponent,
    private teacherService : TeacherService
    ) {
    this.appcomponents.pageTitle = 'Professores'
    this.teacher = new Teacher();
   }

  ngOnInit() {
    this.teacherService.List().subscribe((data : Teacher[]) => {
      this.dataSource = data;
    });
  }

  myTabSelectedIndexChange(index: number) {
    this.selIndex = index;
  }

  onSubmit(){
    this.teacherService.Save(this.teacher).subscribe(r => {
      this.teacher = r;
      location.reload();
    });
  }

  onSelItem(data : Teacher){
    this.teacher = data;
    this.selIndex = 0;
  }

  onDelete(data : Teacher){
    this.teacherService.Delete(data.id).subscribe(r => {location.reload()})
  }

}
