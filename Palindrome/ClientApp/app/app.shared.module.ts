import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { PalindromeComponent } from './components/palindrome/palindrome.component';
import { CheckPalindromeComponent } from './components/checkPalindrome/checkPalindrome.component';
import { CheckPalindromeService } from './components/checkPalindrome/checkPalindrome.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        PalindromeComponent,
        CheckPalindromeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'check', component: CheckPalindromeComponent },
            { path: 'palindromes', component: PalindromeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CheckPalindromeService]
})
export class AppModuleShared {
}
