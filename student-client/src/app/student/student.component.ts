import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentServiceService } from 'src/student-service.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css'],
 
})
export class StudentComponent implements OnInit {
  customerarray: any[]=[];
  clicked:boolean=false;

  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private studentService:StudentServiceService) { }

  ngOnInit(): void {
   this.customerarray= this._Activatedroute.snapshot.data['students'];
  }

}
