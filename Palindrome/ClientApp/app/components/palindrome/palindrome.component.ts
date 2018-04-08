import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Palindrome } from './palindrome.model';
import { PalindromeService } from './palindrome.service';

@Component({
    selector: 'palindromes',
    templateUrl: './palindrome.component.html'
})
export class PalindromeComponent {
    public palindromes: Palindrome[];

    constructor(public palindromeService: PalindromeService) {
        this.GetPalindromes();
    }

    GetPalindromes() {


        this.palindromeService.getPalindromes()
            .subscribe(
            data => {
                console.log(data);
                this.palindromes = data as Palindrome[];
            },
            error => {
                console.log(error);
            });
    }
}


