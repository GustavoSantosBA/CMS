import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Grades } from 'src/app/Model/Grades';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GradesService {


  constructor(private http: HttpClient) { }


  Save(obj : any): Observable<Grades> {
    return this.http.post(`${environment.url.api}Grades`,obj)
  }

  List(): Observable<Grades[]>{
    return this.http.get<Grades[]>(`${environment.url.api}Grades`)
  }

  Delete(id? : number){
    return this.http.delete(`${environment.url.api}Grades/` + id);
  }

}
