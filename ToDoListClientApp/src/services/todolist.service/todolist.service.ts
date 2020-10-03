import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constants } from 'src/common/constants';

@Injectable({
    providedIn:'root'
})
export class ToDoListService {
    constructor ( private http: HttpClient ) {
      
    }

    getToDoItems(): Observable<any> {
        return this.http.get<any>(Constants.ServiceUrls.GetToDoItemsUrl);
    }
}