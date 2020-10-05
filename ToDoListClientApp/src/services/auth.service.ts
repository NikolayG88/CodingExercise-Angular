import { HttpClient } from '@angular/common/http';
import { Constants } from 'src/common/constants';
import { Injectable } from '@angular/core';
import {  map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) {

    }

    isAuthenticated(): boolean {
        if (sessionStorage.getItem(Constants.Session.Token)) {
            return true;
        }

        return false;
    }

    getUserToken(): any {
        return JSON.parse(sessionStorage.getItem(Constants.Session.Token));
    }

    authenticateUser(username, password): Observable<any> {

        var data = `grant_type=password&username=${username}&password=${password}`;

        let result = this.http.post<any>(Constants.ServiceUrls.TokenServiceUrl, data)
        .pipe(      
            map(response => {
            sessionStorage.setItem(Constants.Session.Token, JSON.stringify(response));
        }));
      
        return result;
    }
}