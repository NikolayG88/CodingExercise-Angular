import { ToDoItemStatus } from './todo-item-status';

export class ToDoItemModel {
    Id: number;
    DueIn: Date;
    Name: string;
    Description: string;
    StatusId: ToDoItemStatus;

    constructor(itemId, hdr, desc, due){

        let date = new Date();
        date.setTime(date.getTime() + (due*60*60*1000));
        
        this.Id = itemId;
        this.Name = hdr;
        this.DueIn = date;
        this.Description = desc;
        this.StatusId = this.getStatus();
    }

    getStatus(){

        if(this.StatusId == ToDoItemStatus.Done) return;

        let status = ToDoItemStatus.ToDo;
        var hours = (this.DueIn.getTime() - new Date().getTime()) / 36e5;
        
        if(hours > 12) {
            status = ToDoItemStatus.ToDo;
        } else if (hours > 0 && hours <= 12) {
            status = ToDoItemStatus.DueSoon;
        } else if (hours <= 0) {
            status = ToDoItemStatus.DuePast;
        }

        return status;
    }
}