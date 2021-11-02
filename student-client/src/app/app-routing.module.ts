import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentServiceService } from 'src/student-service.service';
import { ResolverService } from './resolver.service';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentComponent } from './student/student.component';

const routes: Routes = [

  {path: '', component: StudentComponent,resolve: { students: ResolverService }},
  {path: 'student', component: StudentComponent,resolve: { students: ResolverService }},
{path: 'student-detail', component: StudentDetailComponent,resolve:{studentdetails:ResolverService}}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[ResolverService]
})
export class AppRoutingModule { }
