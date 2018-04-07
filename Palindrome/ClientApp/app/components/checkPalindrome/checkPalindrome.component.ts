import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { CheckPalindromeService } from './checkPalindrome.service'
import { NgForm } from '@angular/forms';
import { CheckPalindromeModel } from './checkPalindrome.model'

@Component({
    selector: 'checkPalindrome',
    templateUrl: './checkPalindrome.component.html'
})
export class CheckPalindromeComponent {
    public isPalindrome: boolean;
    model = new CheckPalindromeModel("",false);
    constructor(private checkPalindromeService: CheckPalindromeService) {
        
    }

    SubmitForm(form: NgForm) {

        console.log(form.value)
        this.checkPalindromeService.postPalindromeInput(this.model)
            .subscribe(
            data => {
                console.log("post success");
                console.log(data);
                if (data) this.model.isPalindrome = true
                else { this.model.isPalindrome = false; }
            },
            error => {
                console.log("error");
                console.log(error);
            });
    }
}
