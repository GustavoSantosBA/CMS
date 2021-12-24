import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { Courses } from 'src/app/Model/Courses';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CourseService {

constructor(private http: HttpClient) { }

  Save(obj : any): Observable<Courses> {
    return this.http.post(`${environment.url.api}Courses`,obj)
  }

  List(): Observable<Courses[]>{
    return this.http.get<Courses[]>(`${environment.url.api}Courses`)
  }

  Delete(id? : number){
    return this.http.delete(`${environment.url.api}Courses/` + id);
  }
}
