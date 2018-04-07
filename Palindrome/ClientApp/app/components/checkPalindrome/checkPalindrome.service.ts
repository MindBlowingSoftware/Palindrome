import { Component, Inject, Injectable } from '@angular/core';
import { Http, HttpModule, Response, Headers, RequestOptions } from '@angular/http';
import { CheckPalindromeModel } from './checkPalindrome.model';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class CheckPalindromeService {
    constructor(private http: Http) {

    }

    postPalindromeInput(model: CheckPalindromeModel) : Observable<any> {
        console.log("pallindrome " + model.palindrome);
        console.log("posting to CheckPalindrome Service");

        let url = "/api/CheckPalindrome"
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

