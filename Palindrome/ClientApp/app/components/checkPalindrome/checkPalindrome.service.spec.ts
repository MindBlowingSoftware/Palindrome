import { } from 'jasmine';
import { CheckPalindromeService } from './checkPalindrome.Service'
import { CheckPalindromeModel }  from './checkPalindrome.model'
import { of } from 'rxjs/observable/of';
import { Http, RequestOptions, Headers } from '@angular/http';


describe('CheckPalindromeService',
    () => {
        let checkPalindromeService: CheckPalindromeService, mockHttpObject: any, checkPalindromeInput:any;

        beforeEach(() => {
            mockHttpObject = jasmine.createSpyObj('mockHttpObject');
            checkPalindromeService = new CheckPalindromeService(mockHttpObject);
        });

        describe('checkPalindromeInput',
            () => {
                it('should return a boolean and set isPalindrome in model',
                    () => {
                        let model = new CheckPalindromeModel("", "", "");

                        mockHttpObject.post.and.returnValue(of(true));
                        
                        expect(checkPalindromeService.checkPalindromeInput(model)).toBe(of(true));
                    });
            });
    });


   