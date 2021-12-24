import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subjects } from 'src/app/Model/Subjects';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {


  constructor(private http: HttpClient) { }


  Save(obj : any): Observable<Subjects> {
    return this.http.post(`${environment.url.api}Subjects`,obj)
  }

  List(): Observable<Subjects[]>{
    return this.http.get<Subjects[]>(`${environment.url.api}Subjects`)
  }

  Delete(id? : number){
    return this.http.delete(`${environment.url.api}Subjects/` + id);
  }


}
