import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/app/Model/Stundent';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

constructor(private http: HttpClient) { }


Save(obj : any): Observable<Student> {
  return this.http.post(`${environment.url.api}Student`,obj)
}

List(): Observable<Student[]>{
  return this.http.get<Student[]>(`${environment.url.api}Student`)
}

Delete(id? : number){
  return this.http.delete(`${environment.url.api}Student/` + id);
}

}
