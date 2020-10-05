import { ToDoItemModel } from 'src/app/components/todolist/todo-item/models/todo-item-model';
import { HttpClient } from '@angular/common/http';
import { Constants } from 'src/common/constants';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn:'root'
})
export class ToDoListService {

    constructor ( private http: HttpClient ) {
      
    }

    getToDoItems(): Observable<ToDoItemModel[]> {
        return this.http.get<any>(Constants.ServiceUrls.GetToDoItemsUrl);
    }

    addToDoItem(item: ToDoItemModel): Observable<number> {
        return this.http.post<any>(Constants.ServiceUrls.AddToDoItemUrl, item);
    }

    setItemDone(itemId: number): Observable<any> {
        return this.http.post<any>(Constants.ServiceUrls.SetItemDoneUrl + `?itemId=${itemId}`, null);
    }

    deleteToDoItem(itemId: number): Observable<any> {
        return this.http.post<any>(Constants.ServiceUrls.DeleteToDoItemUrl + `?itemId=${itemId}`, null);
    }
}