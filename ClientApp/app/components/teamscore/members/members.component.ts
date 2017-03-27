import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';

@Component({
    selector: 'members',
    template: require('./members.component.html')
})
export class MembersComponent {
    public members: Member[];

    constructor(http: Http) {
        http.get('/api/Member/Member').subscribe(result => {
            this.members = result.json() as Member[];

        });
    }
}