import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ScoresComponent } from './components/scores/scores.component';
import { SubmitTaskComponent } from './components/submit-task/submit-task.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "submit-task", component: SubmitTaskComponent },
  { path: "scores", component: ScoresComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
