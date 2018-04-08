import { Component, Inject, Injectable } from '@angular/core';
import { Http, HttpModule, Response, Headers, RequestOptions } from '@angular/http';
import { Palindrome } from './palindrome.model';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class PalindromeService {
    constructor(private http: Http) {

    }

    getPalindromes(): Observable<any> {
        
        console.log("fetching to Palindromes from Palindrome API");

        let url = "/api/Palindrome"

        return this.http.get(url)
            .map(this.ExtractData)
            .catch(this.handleError);
    }

    postPalindromeInput(model: Palindrome): Observable<any> {
        console.log(model);
        console.log("posting to Palindrome Service");

        let url = "/api/Palindrome"
        let body = JSON.stringify(model);
        let headers = new Headers({ "Content-Type": "application/json" });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(url, body, options)
            .map(this.ExtractData)
            .catch(this.handleError);
    }

    private ExtractData(res: Response) {
        var body = res.json();
        return body;
    }

    private handleError(error: any) {
        console.log("error" + error);
        return Observable.throw(error.StatusText);
    }
}

