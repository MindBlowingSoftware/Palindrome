import { } from 'jasmine';
import { PalindromeService } from './Palindrome.Service'
import { Palindrome } from './Palindrome.model'
import { of } from 'rxjs/observable/of';
import { Http, RequestOptions, Headers } from '@angular/http';
import { PalindromeComponent } from './Palindrome.component'



describe('PalindromeComponentTest',
    () => {
        let palindromeService: any,
            palindromeComponent: PalindromeComponent

        beforeEach(() => {
            palindromeService = jasmine.createSpyObj("palindromeService");
            palindromeComponent = new PalindromeComponent(palindromeService);
        });

        describe('getPalindromes',
            () => {
                it('should return correct number of pallindromes in database',
                    () => {

                        var palindrome1 = new Palindrome("1");
                        var palindrome2 = new Palindrome("2");
                        var palindromes = new Array(palindrome1, palindrome2);
                        palindromeService.getPalindromes.and.returnValue(of(palindromes));

                        expect(palindromeComponent.palindromes.length).toBe(2);
                    });
            });
    });


