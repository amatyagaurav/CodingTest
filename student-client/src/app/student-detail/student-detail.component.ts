import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentServiceService } from 'src/student-service.service';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit {
subjectCode:string='';
studentarray=[];
  constructor(private router:Router, private _activatedRoute: ActivatedRoute,private studentService:StudentServiceService) { }

  ngOnInit(): void {
    this.studentarray= this._activatedRoute.snapshot.data['studentdetails'];
  }
}
