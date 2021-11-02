import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentServiceService {
 url:string='https://localhost:44318/student';
  constructor(private httpclient: HttpClient) {
    
   }
   getSubjects(): Observable<any[]>{
    return (this.httpclient.get<any[]>(this.url+'/api/GetAllSubjects'));

 }
 getStudentsBySubject(subjectId): Observable<any[]>{
 return (this.httpclient.get<any[]>(this.url+'/api/GetStudentBySubject?SubjectCode=' + subjectId));
 }
}
