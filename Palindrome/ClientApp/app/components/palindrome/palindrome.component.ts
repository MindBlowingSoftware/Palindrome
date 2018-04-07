import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'palindromes',
    templateUrl: './palindrome.component.html'
})
export class PalindromeComponent {
    public palindromes: Palindrome[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Palindrome').subscribe(result => {
            this.palindromes = result.json() as Palindrome[];
            console.log(this.palindromes);
        }, error => console.error(error));
    }
}

interface Palindrome {
    PalindromeId: string;
    PalindromeValue: string;
    CreateTS: Date;
    UpdatedTS: Date;
}
