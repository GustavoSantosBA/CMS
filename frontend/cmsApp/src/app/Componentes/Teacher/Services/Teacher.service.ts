import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Teacher } from 'src/app/Model/Teacher';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

constructor(private http: HttpClient) { }


Save(obj : any): Observable<Teacher> {
  return this.http.post(`${environment.url.api}Teacher`,obj)
}

List(): Observable<Teacher[]>{
  return this.http.get<Teacher[]>(`${environment.url.api}Teacher`)
}

Delete(id? : number){
  return this.http.delete(`${environment.url.api}Teacher/` + id);
}
}
