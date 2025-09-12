import { Component } from "@angular/core";


@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css'],
    standalone: true
})

export class HeaderComponent {
    
    login_action(){
        alert('login action');
        console.log('login action');
    }


}