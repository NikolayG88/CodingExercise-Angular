import { Component } from '@angular/core';
import {ToDoListService} from 'src/services/todolist.service/todolist.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ToDoListWebApp';


  constructor(private service: ToDoListService ) {

    service.getToDoItems().subscribe(res => {
      console.log(res);
    });
  }
}
