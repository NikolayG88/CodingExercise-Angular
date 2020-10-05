import { ToDoListService } from 'src/services/todolist.service/todolist.service';
import { ToDoItemModel } from './todo-item/models/todo-item-model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit } from '@angular/core';
import { ToDoItemStatus } from './todo-item/models/todo-item-status';

@Component({
  selector: 'app-todolist',
  templateUrl: './todolist.component.html',
  styleUrls: ['./todolist.component.scss']
})
export class TodolistComponent implements OnInit {

  itemList: ToDoItemModel[];

  constructor(private service: ToDoListService, private modalService: NgbModal) {

  }

  ngOnInit(): void {
    this.service.getToDoItems().subscribe(result => {
      this.itemList = result;
    },
      error => console.log(error)
    );
  }

  newItemHeader: string;
  newItemDueIn: string;
  newItemDesc: string;

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      if (result === "save") {
        let newItem = new ToDoItemModel(this.itemList.length, this.newItemHeader, this.newItemDesc, this.newItemDueIn);

        this.service.addToDoItem(newItem).subscribe(itemId => {
          newItem.Id = itemId;
          this.itemList.push(newItem);
        });

      }
    }, (reason) => {

    });
  }

  markAsDoneHandler(itemId) {
    this.service.setItemDone(itemId).subscribe(_ =>
      this.itemList.find(item => item.Id == itemId).StatusId = ToDoItemStatus.Done);
  }

  deleteItemHandler(itemId) {
    this.service.deleteToDoItem(itemId).subscribe(_ =>
      this.itemList = this.itemList.filter(item => item.Id !== itemId));
  }
}
