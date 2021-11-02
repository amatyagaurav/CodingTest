import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import bootstrap from "bootstrap";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentComponent } from './student/student.component';

import { StudentDetailComponent } from './student-detail/student-detail.component';
import { ToastrModule } from 'ngx-toastr';
import { ResolverService } from './resolver.service';
import { StudentServiceService } from 'src/student-service.service';




@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    StudentDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(), 
  ],
  providers: [StudentServiceService],
  bootstrap: [AppComponent],
})
export class AppModule { }
