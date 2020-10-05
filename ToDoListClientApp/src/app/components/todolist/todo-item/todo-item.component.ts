import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faCheck, faTimes } from '@fortawesome/free-solid-svg-icons';
import { ToDoItemStatus } from './models/todo-item-status';
import { ToDoItemModel } from './models/todo-item-model';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.scss']
})
export class TodoItemComponent implements OnInit {

  faCheck = faCheck;
  faTimes = faTimes;

  styleMap: string[] = [];
  

  itemStatus: ToDoItemStatus = ToDoItemStatus.ToDo;
  
  @Input() model: ToDoItemModel;
  @Input() index: number;

  @Output() markAsDone = new EventEmitter();
  @Output() deleteItem = new EventEmitter();

  constructor() {

    this.styleMap[ToDoItemStatus.Done] = "success";
    this.styleMap[ToDoItemStatus.ToDo] = "primary" ;
    this.styleMap[ToDoItemStatus.DuePast] = "danger";
    this.styleMap[ToDoItemStatus.DueSoon] = "warning";
   }

  ngOnInit(): void {
    
  }

  ngAfterViewInit(): void {

  }
  
  markAsDoneHandler(): void {
    this.markAsDone.emit(this.model.Id);
  }

  deleteItemhandler(): void {
    this.deleteItem.emit(this.model.Id);
  }

}
