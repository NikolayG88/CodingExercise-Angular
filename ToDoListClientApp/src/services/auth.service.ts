import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from 'src/common/constants';


@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor ( private http: HttpClient ) {
      
    }

    isAuthenticated() : boolean {
       if(sessionStorage.getItem(Constants.Session.Token)){
           return true;
       }

       return false;
    }

    getUserToken(): any{
        return sessionStorage.getItem(Constants.Session.Token);
    }
    authenticateUser(username, password): Observable<any> {

        var data = `grant_type=password&username=${username}&password=${password}`;
        return this.http.post<any>(Constants.ServiceUrls.TokenServiceUrl, data);
        // .pipe<any>(
        //     map(response => {
        //        console.log('saving token', response);
        //        sessionStorage.setItem(Constants.Session.Token, response);
        //     })
        // );
    }
                                                  
}