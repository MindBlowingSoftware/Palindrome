import { } from 'jasmine';
import { CheckPalindromeService } from './checkPalindrome.Service'
import { CheckPalindromeModel } from './checkPalindrome.model'
import { of } from 'rxjs/observable/of';
import { Http, RequestOptions, Headers } from '@angular/http';
import { CheckPalindromeComponent } from './checkPalindrome.component'
import { PalindromeService } from '../palindrome/palindrome.service';


describe('CheckPalindromeComponentTest',
    () => {
        let checkPalindromeService : any,
            checkPalindromeComponent: CheckPalindromeComponent,
            palindromeService: any;
        

        beforeEach(() => {
            checkPalindromeService = jasmine.createSpyObj("checkPalindromeService");
            palindromeService = jasmine.createSpyObj("palindromeService");
            checkPalindromeComponent = new CheckPalindromeComponent(checkPalindromeService, palindromeService);
        });

        describe('postPalindromeInput',
            () => {
                it('should save',
                    () => {
                        palindromeService.postPalindromeInput.and.returnValue(of("Saved"));

                        expect(checkPalindromeComponent.model.saveStatus).toBe("Saved");
                    });
            });

        describe('checkPalindromeInput',
            () => {
                it('should set isPalindrome with correct result ',
                    () => {
                        palindromeService.checkPalindromeInput.and.returnValue(of("true"));

                        expect(checkPalindromeComponent.model.isPalindrome).toBe("true");
                    });
            });
    });


