import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from "../models/task"
import { TaskSubmit } from '../models/taskSubmit';
import { TaskSubmitResult } from '../models/taskSubmitResult';

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Task[]> {
    return this.httpClient.get<Task[]>("https://localhost:44306/api/tasks");
  }

  submit(taskSubmit: TaskSubmit): Observable<TaskSubmitResult> {
    console.log(taskSubmit)
    return this.httpClient.post<TaskSubmitResult>("https://localhost:44306/api/tasks", taskSubmit);
  }
}
