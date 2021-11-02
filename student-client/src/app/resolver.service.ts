import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import { StudentServiceService } from 'src/student-service.service';

@Injectable()
export class ResolverService implements Resolve<Observable<any>>{

  constructor(private productService: StudentServiceService, private router: Router, private toastr: ToastrService) {
  }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): any {
    let id = route.queryParams.id;
    if (id) {
   return  this.productService.getStudentsBySubject(id)
        .pipe( mergeMap(data => {
             if (data.length>0) {
                return of(data)
             } else {
             alert('Error! Subject code is incorrect. Redirected to main page!')
                this.router.navigate(['']);
             }
           })
         )
        
    }
    else {
      return this.productService.getSubjects();
    }

  }
}