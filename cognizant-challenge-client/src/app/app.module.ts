import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubmitTaskComponent } from './components/submit-task/submit-task.component';
import { HomeComponent } from './components/home/home.component';
import { ScoresComponent } from './components/scores/scores.component';

@NgModule({
  declarations: [
    AppComponent,
    SubmitTaskComponent,
    HomeComponent,
    ScoresComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
