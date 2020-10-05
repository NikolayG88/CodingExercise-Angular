import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

import { AuthService } from 'src/services/auth.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor (private auth: AuthService, private router: Router) {}
    
    intercept (request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
        if(this.auth.isAuthenticated()){
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.auth.getUserToken().access_token}`
                }
            });
        } 

        return next.handle(request).pipe( tap(() => {},
            (err: any) => {
            if (err instanceof HttpErrorResponse) {
                if (err.status !== 401) {
                    return;
                }
                this.router.navigate(['login']);
            }
            }));
        }

}