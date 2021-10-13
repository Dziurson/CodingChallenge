import { Component, OnInit } from '@angular/core';
import { TasksService } from 'src/app/services/tasks.service';
import { Task } from "../../models/task"

@Component({
  selector: 'submit-task',
  templateUrl: './submit-task.component.html',
  styleUrls: ['./submit-task.component.scss']
})
export class SubmitTaskComponent implements OnInit {

  public tasks: Task[];
  public selectedTask: Task;
  public solutionCode: string;
  public name: string;
  public output: string;

  constructor(private tasksService: TasksService) { }

  ngOnInit(): void {
    this.tasksService.getAll().subscribe(tasks => {
      this.tasks = tasks;
    })
  }

  onTaskChange(event: Event) {
    var selectedTaskId = (event.target as HTMLSelectElement).value;
    this.selectedTask = this.tasks.filter(t => t.externalId == selectedTaskId)[0];
  }

  onTaskSubmit() {
    this.tasksService.submit({
      name: this.name,
      solution: this.solutionCode,
      taskExternalId: this.selectedTask.externalId
    }).subscribe(result => {
      this.output = `${result.output}\nStatusCode: ${result.statusCode}\nSuccess: ${result.success}`
    });
  }

}
