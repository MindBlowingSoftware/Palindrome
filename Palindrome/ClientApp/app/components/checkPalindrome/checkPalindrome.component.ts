import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { CheckPalindromeService } from './checkPalindrome.service'
import { NgForm } from '@angular/forms';
import { CheckPalindromeModel } from './checkPalindrome.model'
import { PalindromeService } from '../palindrome/palindrome.service';
import { Palindrome } from '../palindrome/palindrome.model';

@Component({
    selector: 'checkPalindrome',
    templateUrl: './checkPalindrome.component.html'
})
export class CheckPalindromeComponent {
    public isPalindrome: boolean;
    model = new CheckPalindromeModel("",false,"");
    constructor(private checkPalindromeService: CheckPalindromeService,
    private palindromeSevice: PalindromeService) {
        
    }

    SubmitForm(form: NgForm) {

        console.log(form.value)
        this.checkPalindromeService.checkPalindromeInput(this.model)
            .subscribe(
            data => {
                console.log("post success");
                console.log(data);
                if (data) {
                    this.model.isPalindrome = true;
                    this.model.saveStatus = "Saving to database...";

                    let palindrome = new Palindrome(this.model.palindromeValue);
                    this.palindromeSevice.postPalindromeInput(palindrome)
                        .subscribe(
                        data => {
                            this.model.saveStatus = data;
                        },
                        error => {
                            console.log(error);
                            this.model.saveStatus = error;
                        }
                        );
                }
                else { this.model.isPalindrome = false; }
            },
            error => {
                console.log("error");
                console.log(error);
            });
    }
}
